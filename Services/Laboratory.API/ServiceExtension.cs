using System;
using Laboratory.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.Common.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;
using Mapster;
using MapsterMapper;
using Laboratory.API.Repositories;
using Laboratory.API.Entities;
using Laboratory.API.Dtos;

namespace Laboratory.API;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ILaboratorioRepository, LaboratorioRepository>();
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

        config.NewConfig<Laboratorio, LaboratorioReadDto>()
            .TwoWays();

        config.Scan(Assembly.GetExecutingAssembly());
    }
}

