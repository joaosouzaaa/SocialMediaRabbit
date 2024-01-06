﻿using Microsoft.EntityFrameworkCore;
using ProfileMicroService.API.Data.DatabaseContexts;
using ProfileMicroService.API.Factories;

namespace ProfileMicroService.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjectionHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();

        var rm = configuration.GetConnectionString();
        services.AddDbContext<ProfileDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString());
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        services.AddSettingsDependencyInjection();
        services.AddFiltersDependencyInjection();
        services.AddRepositoriesDependencyInjection();
        services.AddMappersDependencyInjection();
        services.AddValidatorsDependencyInjection();
        services.AddServicesDependencyInjection();
    }
}
