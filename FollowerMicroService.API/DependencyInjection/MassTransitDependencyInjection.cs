using MassTransit;

namespace FollowerMicroService.API.DependencyInjection;

public static class MassTransitDependencyInjection
{
    public static void AddMassTransitDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();

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
