using System;
using System.Reflection;
using Mapster;
using MapsterMapper;
using RequestService.Dtos;
using RequestService.Models;

namespace RequestService;

public static class ServiceExtension
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        config.NewConfig<Request, RequestReadDto>()
            .TwoWays();

        config.Scan(Assembly.GetExecutingAssembly());
    }
}

