using Azure.Messaging.ServiceBus;
using Masstransit.Publisher.Domain.Classes.Statics;
using Masstransit.Publisher.Domain.Interfaces;

namespace Masstransit.Publisher.Services.Services
{
    public class FaultQueueListenerService : IDisposable, IAsyncDisposable
    {
        private ServiceBusClient? _client;
        private ServiceBusProcessor? _processor;
        private readonly ILogService _logService;
        private bool _isListening;

        public FaultQueueListenerService(ILogService logService)
        {
            _logService = logService;
        }

        public async Task StartListeningAsync(string connectionString, string queueName)
        {
            if (_isListening)
            {
                await _logService.Send(Queues.Log, new LogMessage("Fault queue listener is already running", string.Empty));
                return;
            }

            try
            {
                _client = new ServiceBusClient(connectionString);
                _processor = _client.CreateProcessor(queueName, new ServiceBusProcessorOptions
                {
                    ReceiveMode = ServiceBusReceiveMode.PeekLock,
                    AutoCompleteMessages = false,
                    MaxConcurrentCalls = 1
                });

                _processor.ProcessMessageAsync += MessageHandler;
                _processor.ProcessErrorAsync += ErrorHandler;

                await _processor.StartProcessingAsync();
                _isListening = true;

                await _logService.Send(Queues.Log, $"Started listening to fault queue: {queueName}");
            }
            catch (Exception ex)
            {
                await _logService.Send(Queues.Log, $"Error starting fault queue listener: {ex.Message}");
                throw;
            }
        }

        public async Task StopListeningAsync()
        {
            if (!_isListening)
            {
                return;
            }

            try
            {
                if (_processor != null)
                {
                    await _processor.StopProcessingAsync();
                    await _logService.Send(Queues.Log, "Stopped listening to fault queue");
                }

                _isListening = false;
            }
            catch (Exception ex)
            {
                await _logService.Send(Queues.Log, $"Error stopping fault queue listener: {ex.Message}");
            }
        }

        private async Task MessageHandler(ProcessMessageEventArgs args)
        {
            try
            {
                var body = args.Message.Body.ToString();

                var messageId = args.Message.MessageId;

                await _logService.Send(Queues.Log, new LogMessage($"Fault message received - MessageId: {messageId}", body));
            }
            catch (Exception ex)
            {
                await _logService.Send(Queues.Log, $"Error processing fault message: {ex.Message}");
            }
        }

        private async Task ErrorHandler(ProcessErrorEventArgs args)
        {
            await _logService.Send(Queues.Log, $"Fault queue listener error: {args.Exception.Message}");
        }

        public void Dispose()
        {
            if (_processor != null)
            {
                _processor.StopProcessingAsync().GetAwaiter().GetResult();
                _processor.DisposeAsync().AsTask().GetAwaiter().GetResult();
            }

            _client?.DisposeAsync().AsTask().GetAwaiter().GetResult();
        }

        public async ValueTask DisposeAsync()
        {
            if (_processor != null)
            {
                await _processor.StopProcessingAsync();
                await _processor.DisposeAsync();
            }

            if (_client != null)
            {
                await _client.DisposeAsync();
            }
        }
    }
}
