using Masstransit.Publisher.Domain.Classes;

namespace Masstransit.Publisher.Domain.Interfaces
{
    public interface IPublisherService
    {
        Task<PublisherServiceResponse> Publish(ContractMessage eventoRecebido);
        Task<List<PublisherServiceResponse>> Publish(IEnumerable<ContractMessage> events);
        Task<PublisherServiceResponse> Send(ContractMessage eventoRecebido, string queue);
        Task<List<PublisherServiceResponse>> Send(IEnumerable<ContractMessage> events, string queue);
    }
}