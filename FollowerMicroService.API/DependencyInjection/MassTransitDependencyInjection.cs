using MassTransit;

namespace FollowerMicroService.API.DependencyInjection;

public static class MassTransitDependencyInjection
{
    public static void AddMassTransitDependencyInjection(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri("amqp://rabbitmq-container:5672"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(context);
            });
        });
    }
}
