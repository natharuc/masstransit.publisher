using Masstransit.Publisher.Domain.Interfaces;

namespace Masstransit.Publisher.Services.Services
{
    public class LogService : ILogService
    {
        private readonly Dictionary<string, Dictionary<string, Action<string>>> _subscribers = new Dictionary<string, Dictionary<string, Action<string>>>();

        public Task Send(string queue, string message)
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

        public Task Subscribe(string name, string queue, Action<string> action)
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
                _subscribers.Add(queue, new Dictionary<string, Action<string>> { { name, action } });
            }

            return Task.CompletedTask;
        }
    }
}
