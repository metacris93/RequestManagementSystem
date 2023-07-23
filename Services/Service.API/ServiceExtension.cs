using System;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Service.API.Dtos;
using Service.API.Entities;
using Service.API.Repositories;
using Service.API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
                //options.UseSqlite("Data Source=.\\Database\\services.db");
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
    public static IServiceCollection AddJwtBearerAuthentication(this IServiceCollection services, IConfigurationSection section)
    {
        var secret = section.GetValue<string>("Secret");
        var issuer = section.GetValue<string>("Issuer");
        var audience = section.GetValue<string>("Audience");
        var key = Encoding.ASCII.GetBytes(secret);
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                ValidateAudience = true,
            };
        });
        return services;
    }
}

