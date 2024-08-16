namespace Masstransit.Publisher.Domain.Interfaces
{
    public interface ILogService
    {
        Task Send(string queue, string message);
        Task Subscribe(string name, string queue, Action<string> action);
    }
}
