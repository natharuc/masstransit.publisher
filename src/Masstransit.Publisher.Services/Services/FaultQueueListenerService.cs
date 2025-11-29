using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
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
        private bool _isDisposing;

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
                // Ensure queue exists, create if not
                await EnsureQueueExistsAsync(connectionString, queueName);

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

        private async Task EnsureQueueExistsAsync(string connectionString, string queueName)
        {
            try
            {
                var adminClient = new ServiceBusAdministrationClient(connectionString);

                // Check if queue exists
                var queueExists = await adminClient.QueueExistsAsync(queueName);

                if (!queueExists)
                {
                    await _logService.Send(Queues.Log, $"Queue '{queueName}' not found. Creating it...");

                    var queueOptions = new CreateQueueOptions(queueName)
                    {
                        // Optional: Configure queue properties
                        DefaultMessageTimeToLive = TimeSpan.FromDays(14),
                        MaxDeliveryCount = 10,
                        EnableBatchedOperations = true,
                        LockDuration = TimeSpan.FromMinutes(5)
                    };

                    await adminClient.CreateQueueAsync(queueOptions);
                    await _logService.Send(Queues.Log, $"Queue '{queueName}' created successfully");
                }
            }
            catch (Azure.RequestFailedException ex) when (ex.Status == 404)
            {
                // Queue doesn't exist, create it
                await _logService.Send(Queues.Log, $"Queue '{queueName}' not found (404). Creating it...");

                var adminClient = new ServiceBusAdministrationClient(connectionString);
                
                var queueOptions = new CreateQueueOptions(queueName)
                {
                    DefaultMessageTimeToLive = TimeSpan.FromDays(14),
                    MaxDeliveryCount = 10,
                    EnableBatchedOperations = true,
                    LockDuration = TimeSpan.FromMinutes(5)
                };

                await adminClient.CreateQueueAsync(queueOptions);
                await _logService.Send(Queues.Log, $"Queue '{queueName}' created successfully");
            }
            catch (Exception ex)
            {
                await _logService.Send(Queues.Log, $"Error checking/creating queue: {ex.Message}");
                // Don't throw here, let the processor creation fail if needed
            }
        }

        public async Task StopListeningAsync()
        {
            if (!_isListening || _isDisposing)
            {
                return;
            }

            _isDisposing = true;

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
            if (_isDisposing)
            {
                // Don't process new messages if disposing
                return;
            }

            try
            {
                var body = args.Message.Body.ToString();

                var messageId = args.Message.MessageId;

                await _logService.Send(Queues.Log, new LogMessage($"Fault message received - MessageId: {messageId}", body));

                // Complete the message after processing
                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception ex)
            {
                await _logService.Send(Queues.Log, $"Error processing fault message: {ex.Message}");
                
                // Abandon the message so it can be retried
                try
                {
                    await args.AbandonMessageAsync(args.Message);
                }
                catch
                {
                    // Ignore abandon errors
                }
            }
        }

        private async Task ErrorHandler(ProcessErrorEventArgs args)
        {
            if (!_isDisposing)
            {
                await _logService.Send(Queues.Log, $"Error in fault queue listener: {args.Exception.Message}");
            }
        }

        public void Dispose()
        {
            // Don't block here - fire and forget the async dispose
            _ = Task.Run(async () =>
            {
                try
                {
                    await DisposeAsync();
                }
                catch
                {
                    // Suppress exceptions during dispose
                }
            });
        }

        public async ValueTask DisposeAsync()
        {
            if (_isDisposing)
            {
                return;
            }

            _isDisposing = true;

            try
            {
                if (_processor != null)
                {
                    // Use a timeout to prevent hanging
                    var stopTask = _processor.StopProcessingAsync();
                    var completedTask = await Task.WhenAny(stopTask, Task.Delay(TimeSpan.FromSeconds(3)));
                    
                    if (completedTask == stopTask)
                    {
                        await stopTask; // Get any exceptions
                    }

                    await _processor.DisposeAsync();
                }

                if (_client != null)
                {
                    await _client.DisposeAsync();
                }
            }
            catch
            {
                // Suppress exceptions during dispose
            }
        }
    }
}
