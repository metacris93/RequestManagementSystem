using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Services.Common.Swagger;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var descr in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(descr.GroupName, ProvideApiInfo(descr));
        }
    }

    private OpenApiInfo ProvideApiInfo(ApiVersionDescription descr)
    {
        var info = new OpenApiInfo()
        {
            Title = "API Microservice",
            Version = descr.ApiVersion.ToString(),
            Contact = new OpenApiContact() { Name = "SAPE", Email = "sape@hueso.dev" },
            License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
        };
        if (descr.IsDeprecated)
        {
            info.Description += " API Version has been deprecated!!!";
        }

        return info;
    }
}

