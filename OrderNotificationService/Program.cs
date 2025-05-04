using OrderNotificationService.Consumers;
using OrderNotificationService.DTOs;
using OrderNotificationService.Services;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        // Регистрация настроек через IOptions
        services.Configure<RabbitMQSettings>(context.Configuration.GetSection("RabbitMQ"));
        services.Configure<EmailSettings>(context.Configuration.GetSection("EmailSettings"));

        // Регистрация сервисов
        services.AddSingleton<IEmailService, EmailService>();
        services.AddHostedService<OrderConsumer>();
    })
    .Build();

await host.RunAsync();