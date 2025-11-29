namespace Masstransit.Publisher.Domain.Interfaces
{
    public interface ILogService
    {
        Task Send(string queue, string message);
        Task Send(string queue, LogMessage message);
        Task Subscribe(string name, string queue, Action<LogMessage> action);
    }

    public sealed record LogMessage (string Message, string Body)
    {
        public override string ToString()
        {
            return Message;
        }
    }
}
