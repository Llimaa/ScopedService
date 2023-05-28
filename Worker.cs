namespace ScopedService;

public class Worker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public Worker(IServiceProvider serviceProvider) => 
        (_serviceProvider) = (serviceProvider);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using(IServiceScope scope = _serviceProvider.CreateScope()) 
        {
            IScopedProcessingService scopedProcessingService = 
                scope.ServiceProvider.GetRequiredService<IScopedProcessingService>();

            await scopedProcessingService.DoWorkAsync(stoppingToken);
        }
    }
}
