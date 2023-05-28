using ScopedService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
