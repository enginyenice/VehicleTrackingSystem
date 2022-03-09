using Core.MessageBroker.RabbitMQ;
using RabbitMQ.Client;
using WorkerAPP;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IRabbitMQClientService, RabbitMQClientService>();
        services.AddSingleton(typeof(IRabbitMQPublisher<>), typeof(RabbitMQPublisher<>));
        IConfiguration configuration = hostContext.Configuration;
        services.AddSingleton(sp => new ConnectionFactory() { Uri = new Uri(configuration.GetConnectionString("RabbitMQ")), DispatchConsumersAsync = true });
    })
    .Build();

await host.RunAsync();