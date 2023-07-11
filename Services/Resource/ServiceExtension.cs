using System;
using Mapster;
using MapsterMapper;
using System.Reflection;
using ResourceService.Models;
using ResourceService.Dtos;

namespace ResourceService;

public static class ServiceExtension
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        config.NewConfig<Department, DepartmentReadDto>()
            .TwoWays();

        config.Scan(Assembly.GetExecutingAssembly());
    }
}

