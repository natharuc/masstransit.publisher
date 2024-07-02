using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Domain.Interfaces;
using Masstransit.Publisher.Services.Extensions;
using MassTransit;

namespace Masstransit.Publisher.Services.Services
{
    public class PublisherService : IPublisherService
    {
        private IBusControl? _busControl;

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
                var evento = JsonToInterfaceConverter.Deserialize(message.Body, message.Contract.Type);

                listaEventos.Add(evento);
            }

            await _busControl.PublishBatch(listaEventos, firstMessage.Contract.Type);

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
                var evento = JsonToInterfaceConverter.Deserialize(message.Body, message.Contract.Type);

                listaEventos.Add(evento);
            }

            var sendEntPoint = await _busControl.GetSendEndpoint(new Uri($"queue:{queue}"));

            await sendEntPoint.SendBatch(listaEventos, firstMessage.Contract.Type);

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
    }
}