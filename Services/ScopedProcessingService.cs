namespace ScopedService;

public sealed class ScopedProcessingService : IScopedProcessingService
{
    private readonly ILogger<ScopedProcessingService> _logger;

    public ScopedProcessingService(
        ILogger<ScopedProcessingService> logger) =>
        _logger = logger;

    public async Task DoWorkAsync(CancellationToken stoppingToken)
    {
        var executionCount = 0;
        while (!stoppingToken.IsCancellationRequested)
        {
            ++ executionCount;

            _logger.LogInformation(
                "Excution count: {Count}", executionCount);

            await Task.Delay(1_000, stoppingToken);
        }
    }
}