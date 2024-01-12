using MassTransit;
using NotificationMicroservice.API.Consumers;

namespace NotificationMicroservice.API.DependencyInjection;

public static class MassTransitDependencyInjection
{
    public static void AddMassTransitDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.AddConsumer<FollowCreatedConsumer>();

            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(configuration["RabbitMqCredentials:Host"]!), h =>
                {
                    h.Username(configuration["RabbitMqCredentials:Username"]);
                    h.Password(configuration["RabbitMqCredentials:Password"]);
                });

                configurator.ConfigureEndpoints(context);
            });
        });
    }
}
