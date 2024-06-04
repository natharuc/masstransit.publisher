using MassTransit;
using Publicador.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Message = Publicador.Classes.Message;

namespace Publicador.Services
{
    public class PublisherService
    {
        private readonly IBusControl _busControl;
        
        public PublisherService(IBusControl busControl)
        {
            _busControl = busControl;
        }

        private async Task<List<PublisherServiceResponse>> Process(IEnumerable<Message> messages, string queue, Func<IEnumerable<Message>, string, Task<PublisherServiceResponse>> action)
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

        public async Task<List<PublisherServiceResponse>> Publish(IEnumerable<Message> events)
        {
            return await Process(events, string.Empty,async (eventos, queue) =>
            {
                return await _Publish(eventos);
            });
        }

        public async Task<PublisherServiceResponse> Publish(Message eventoRecebido)
        {
            var eventos = new List<Message> { eventoRecebido };

            var result = await Publish(eventos);

            return result.First();
        }

        public async Task<PublisherServiceResponse> Send(Message eventoRecebido, string queue)
        {
            var eventos = new List<Message> { eventoRecebido };

            var result = await Send(eventos, queue);

            return result.First();
        }

        public async Task<List<PublisherServiceResponse>> Send(IEnumerable<Message> events, string queue)
        {
            return await Process(events, queue, async (eventos, _queue) =>
            {
                return await _Send(eventos, _queue);
            });
        }

        private async Task<PublisherServiceResponse> _Publish(IEnumerable<Message> events)
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

        private async Task<PublisherServiceResponse> _Send(IEnumerable<Message> events, string queue)
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

    }

    public static class ObjectExtensions
    {
        public static void SetPropertyValue(this object obj, string propertyName, object value)
        {
            obj.GetType().GetProperty(propertyName).SetValue(obj, value);
        }
    }

    public class PublisherServiceResponse
    {
        public Contract Contract { get; set; }
        public int SendedEvents { get; set; }
        public string Message { get; set; }
    }

    public static class ListExtensions
    {
        public static List<List<T>> Paginar<T>(this List<T> lista, int tamanhoPagina)
        {
            var paginas = new List<List<T>>();

            var pagina = new List<T>();

            foreach (var item in lista)
            {
                pagina.Add(item);

                if (pagina.Count == tamanhoPagina)
                {
                    paginas.Add(pagina);

                    pagina = new List<T>();
                }
            }

            if (pagina.Any())
            {
                paginas.Add(pagina);
            }

            return paginas;
        }

        public static List<List<T>> Page<T>(this IEnumerable<T> lista, int tamanhoPagina)
        {
            return lista.ToList().Paginar(tamanhoPagina);
        }
    }
}