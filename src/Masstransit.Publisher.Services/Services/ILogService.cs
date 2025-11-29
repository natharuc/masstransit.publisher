using Masstransit.Publisher.Domain.Interfaces;

namespace Masstransit.Publisher.Services.Services
{
    public class LogService : ILogService
    {
        private readonly Dictionary<string, Dictionary<string, Action<LogMessage>>> _subscribers = new Dictionary<string, Dictionary<string, Action<LogMessage>>>();

        public Task Send(string queue, LogMessage message)
        {
            if (_subscribers.ContainsKey(queue))
            {
                foreach (var subscriber in _subscribers[queue])
                {
                    subscriber.Value(message);
                }
            }

            return Task.CompletedTask;
        }

        public async Task Send(string queue, string message)
        {
            await Send(queue, new LogMessage(message, string.Empty));
        }

        public Task Subscribe(string name, string queue, Action<LogMessage> action)
        {
            if (_subscribers.ContainsKey(queue))
            {
                if (_subscribers[queue].ContainsKey(name))
                {
                    _subscribers[queue][name] = action;
                }
                else
                {
                    _subscribers[queue].Add(name, action);
                }

            }
            else
            {
                _subscribers.Add(queue, new Dictionary<string, Action<LogMessage>> { { name, action } });
            }

            return Task.CompletedTask;
        }
    }
}
