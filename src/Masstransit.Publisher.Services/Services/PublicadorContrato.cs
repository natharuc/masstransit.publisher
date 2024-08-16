using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Domain.Classes.Statics;
using Masstransit.Publisher.Domain.Interfaces;
using Masstransit.Publisher.Services.Extensions;
using MassTransit;
using MassTransit.Courier.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Masstransit.Publisher.Services.Services
{
    public class PublisherService : IPublisherService
    {
        private IBusControl? _busControl;
        private readonly ILogService _logService;

        public PublisherService(ILogService logService)
        {
            _logService = logService;
        }

        private async Task<List<PublisherServiceResponse>> Process(IEnumerable<ContractMessage> messages, string queue, Func<IEnumerable<ContractMessage>, string, Task<PublisherServiceResponse>> action)
        {
            var result = new List<PublisherServiceResponse>();

            var pages = messages.Page(100);

            foreach (var pagina in pages)
            {
                var messagesByType = pagina.GroupBy(n => n.Contract);

                foreach (var eventosPorTipo in messagesByType)
                {
                    var publishResult = await action(eventosPorTipo.Select(n => n), queue);

                    result.Add(publishResult);
                }
            }

            return result
                .GroupBy(x => x.Contract)
                .Select(x => new PublisherServiceResponse
                {
                    Contract = x.Key,
                    SendedEvents = x.Sum(n => n.SendedEvents),
                    Message = x.First().Message

                }).ToList();
        }

        public async Task<List<PublisherServiceResponse>> Publish(IEnumerable<ContractMessage> events)
        {
            return await Process(events, string.Empty, async (eventos, queue) =>
            {
                return await _publish(eventos);
            });
        }

        public async Task<PublisherServiceResponse> Publish(ContractMessage eventoRecebido)
        {
            var eventos = new List<ContractMessage> { eventoRecebido };

            var result = await Publish(eventos);

            return result.First();
        }

        public async Task<PublisherServiceResponse> Send(ContractMessage eventoRecebido, string queue)
        {
            var eventos = new List<ContractMessage> { eventoRecebido };

            var result = await Send(eventos, queue);

            return result.First();
        }

        public async Task<List<PublisherServiceResponse>> Send(IEnumerable<ContractMessage> events, string queue)
        {
            return await Process(events, queue, async (eventos, _queue) =>
            {
                return await _send(eventos, _queue);
            });
        }

        private async Task<PublisherServiceResponse> _publish(IEnumerable<ContractMessage> events)
        {

            var firstMessage = events.First();
            if (!firstMessage.HasContractType)
                throw new InvalidOperationException("Contract not found.");

            var listaEventos = new List<object>();

            foreach (var message in events)
            {
                var evento = JsonToInterfaceConverter.Deserialize(message.Body, message.Contract.GetFullType());

                listaEventos.Add(evento);
            }

            await _busControl.PublishBatch(listaEventos, firstMessage.Contract.GetFullType());

            await _logService.Send(Queues.Log, $"{listaEventos.Count} events has been published to {firstMessage.Contract}");

            return new PublisherServiceResponse
            {
                Contract = firstMessage.Contract,
                SendedEvents = listaEventos.Count,
                Message = "Success."
            };
        }

        private async Task<PublisherServiceResponse> _send(IEnumerable<ContractMessage> events, string queue)
        {

            var firstMessage = events.First();

            if (!firstMessage.HasContractType)
                throw new InvalidOperationException("Contract not found.");

            var listaEventos = new List<object>();

            foreach (var message in events)
            {
                var evento = JsonToInterfaceConverter.Deserialize(message.Body, message.Contract.GetFullType());

                listaEventos.Add(evento);
            }

            var sendEntPoint = await _busControl.GetSendEndpoint(new Uri($"queue:{queue}"));

            await sendEntPoint.SendBatch(listaEventos, firstMessage.Contract.GetFullType());

            await _logService.Send(Queues.Log, $"{listaEventos.Count} events has been seended to {queue}");

            return new PublisherServiceResponse
            {
                Contract = firstMessage.Contract,
                SendedEvents = listaEventos.Count,
                Message = "Success."
            };
        }

        public void Setup(IBusControl busControl)
        {
            _busControl = busControl;
        }


        private Guid GetTrackingNumber(string json, ActivitySettings activitySettings)
        {
            if (string.IsNullOrEmpty(json))
                throw new InvalidOperationException("Json is required to get the tracking number");

            var jsonObject = JsonConvert.DeserializeObject<JObject>(json);

            if (jsonObject == null)
                throw new InvalidOperationException("Json is invalid");

            if (string.IsNullOrEmpty(activitySettings.TrackingNumberProperty))
                throw new InvalidOperationException("Activity settings is required to get the tracking number");

            var token = jsonObject.SelectToken(activitySettings.TrackingNumberProperty);

            if (token != null)
            {
                if (Guid.TryParse(token.ToString(), out var trackingNumber))
                {
                    return trackingNumber;
                }
                else
                {
                    throw new InvalidOperationException("Tracking number is invalid");
                }
            }


            throw new InvalidOperationException("Tracking number property not found");
        }


        public async Task ExecuteActivity(ContractMessage conctractMessage, ActivitySettings activitySettings)
        {
            if (_busControl == null)
                throw new InvalidOperationException("Bus control is required to execute the activity");

            if (activitySettings == null)
                throw new InvalidOperationException("Activity settings is required to execute the activity");

            if (activitySettings.Activities.Count == 0)
                throw new InvalidOperationException("Activity settings is required to execute the activity");

            if (string.IsNullOrEmpty(activitySettings.FaultQueue))
                throw new InvalidOperationException("Fault queue is required to execute the activity");

            if (string.IsNullOrEmpty(activitySettings.SuccessQueue))
                throw new InvalidOperationException("Success queue is required to execute the activity");

            if (string.IsNullOrEmpty(conctractMessage.Body))
                throw new InvalidOperationException("Message body is required to execute the activity");

            var trakingNumber = GetTrackingNumber(conctractMessage.Body, activitySettings);

            var slipBuilder = new RoutingSlipBuilder(trakingNumber);

            var message = JsonToInterfaceConverter.Deserialize(conctractMessage.Body, conctractMessage.Contract.GetFullType());

            foreach (var activity in activitySettings.Activities)
            {
                slipBuilder.AddActivity(activity.Name, new Uri($"queue:{activity.Queue}"));
            }

            await slipBuilder.AddSubscription(new Uri($"queue:{activitySettings.FaultQueue}"),
                  RoutingSlipEvents.Faulted, RoutingSlipEventContents.All, x =>
                  {
                      return x.Send(new ActivityFaulted()
                      {
                          TrackingNumber = trakingNumber,
                          Message = message
                      });
                  });

            await slipBuilder.AddSubscription(new Uri($"queue:{activitySettings.SuccessQueue}"),
                 RoutingSlipEvents.Completed, RoutingSlipEventContents.All, x =>
                 {
                     return x.Send(new ActivityCompleted()
                     {
                         TrackingNumber = trakingNumber,
                         Message = message
                     });
                 });

            slipBuilder.SetVariables(message);

            var routingSlip = slipBuilder.Build();
            
            await _busControl.Execute(routingSlip);

            await _logService.Send(Queues.Log, $"Activity {activitySettings.Activities[0].Name} started with tracking number {trakingNumber}");
        }

        public async Task ExecuteActivity(IEnumerable<ContractMessage> messages, ActivitySettings activitySettings)
        {
            foreach (var message in messages)
            {
                await ExecuteActivity(message, activitySettings);
            }
        }
    }
}