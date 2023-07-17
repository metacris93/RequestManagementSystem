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
	public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
	{
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddSwaggerGen(options =>
        {
            options.OperationFilter<SwaggerDefaultValues>();
        });
        return services;
    }
	public static IServiceCollection AddApiVersion(this IServiceCollection services)
	{
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        });
        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
        return services;
    }
    public static WebApplication ConfigureSwaggerUI(this WebApplication app)
    {
        app.UseSwaggerUI(options =>
        {
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
        });
        return app;
    }
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        //config.NewConfig<Request, RequestReadDto>()
        //    .TwoWays();

        config.Scan(Assembly.GetExecutingAssembly());
    }
}

