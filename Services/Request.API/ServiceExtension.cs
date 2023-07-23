using System;
using Request.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.Common.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;
using Mapster;
using MapsterMapper;
using Request.API.Repositories;
using Request.API.Entities;
using Request.API.Dtos;

namespace Request.API;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEstadoRepository, EstadoRepository>();
        return services;
    }
	public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
	{
        if (env.IsProduction())
        {
            services.AddDbContextPool<SqlServerContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Connection"));
            });
        }
        else
        {
            services.AddDbContext<SqlServerContext>(options =>
            {
                options.UseInMemoryDatabase("InMem");
                //options.UseSqlite("Data Source=.\\Database\\requests.db");
            });
        }
        
		return services;
	}
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        config.NewConfig<Estado, EstadoReadDto>()
            .TwoWays();

        config.Scan(Assembly.GetExecutingAssembly());
    }
}

