using FluentValidation;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Settings.ValidatorsSettings;

namespace ProfileMicroService.API.DependencyInjection;

public static class ValidatorsDependencyInjection
{
    public static void AddValidatorsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IValidator<Profile>, ProfileValidator>();
    }
}
