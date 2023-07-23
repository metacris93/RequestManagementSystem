using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RequestManagementAPIGateway;

public static class ServiceExtension
{
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
