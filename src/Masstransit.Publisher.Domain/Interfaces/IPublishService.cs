using Masstransit.Publisher.Domain.Classes;
using MassTransit;

namespace Masstransit.Publisher.Domain.Interfaces
{
    public interface IPublisherService
    {
        void Setup(IBusControl busControl);
        Task<PublisherServiceResponse> Publish(ContractMessage eventoRecebido);
        Task<List<PublisherServiceResponse>> Publish(IEnumerable<ContractMessage> events);
        Task<PublisherServiceResponse> Send(ContractMessage eventoRecebido, string queue);
        Task<List<PublisherServiceResponse>> Send(IEnumerable<ContractMessage> events, string queue);
        Task ExecuteActivity(ContractMessage conctractMessage, ActivitySettings activitySettings);
    }
}