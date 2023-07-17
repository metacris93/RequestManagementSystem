using System;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Service.API.Dtos;
using Service.API.Entities;
using Service.API.Repositories;
using Service.API.Data;

namespace Service.API;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
        return services;
    }
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {
        if (env.IsProduction())
        {
            services.AddDbContext<SqlServerContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Connection"));
            });
        }
        else
        {
            services.AddDbContext<SqlServerContext>(options =>
            {
                options.UseInMemoryDatabase("InMem");
            });
        }

        return services;
    }
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        config.NewConfig<Departamento, DepartamentoReadDto>()
            .TwoWays();

        config.Scan(Assembly.GetExecutingAssembly());
    }
}

