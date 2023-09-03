using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQGenerateExcelTutorial.FileCreateWorkerService;
using RabbitMQGenerateExcelTutorial.FileCreateWorkerService.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        var configSettings = new ConfigurationBuilder().
        AddJsonFile("appsettings.json").Build();

        services.AddSingleton(sp => new ConnectionFactory()
        {
            Uri = new Uri(configSettings["ConnectionStrings:RabbbitMQUrl"]),
            DispatchConsumersAsync = true
        });

        services.AddSingleton<RabbitMQClientService>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
