﻿namespace Mwh.Sample.SwaggerCore.Extensions;

/// <summary>
/// Extensions to Services to configure Swagger/Open API
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddVersioning().AddCustomSwagger(configuration);
    }

    private static IServiceCollection AddVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(setup =>
        {
            setup.DefaultApiVersion = new ApiVersion(1, 0);
            setup.AssumeDefaultVersionWhenUnspecified = true;
            setup.ReportApiVersions = true;
        });

        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
    /// <summary>
    /// Custom Swagger for Services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(cfg =>
        {
            cfg.SwaggerDoc(configuration.GetValue<string>("Swagger:ApiVersion"),
                new OpenApiInfo
                {
                    Title = configuration.GetValue<string>("Swagger:ApiTitle"),
                    Version = configuration.GetValue<string>("Swagger:ApiVersion"),
                    Description = $"<a href='/'>Back To Home</a><p>{configuration.GetValue<string>("Swagger:ApiDescription")}</p>",
                    Contact = new OpenApiContact
                    {
                        Name = configuration.GetValue<string>("Swagger:UserProfile:Name"),
                        Url = new Uri(configuration.GetValue<string>("Swagger:UserProfile:Url") ?? string.Empty),
                        Email = configuration.GetValue<string>("Swagger:UserProfile:Email"),
                    },
                    License = new OpenApiLicense { Name = "MIT", },
                });

            var xmlFile = configuration.GetValue<string>("Swagger:XmlFile") ?? string.Empty;
            string xmlPath = string.Empty;

            if (File.Exists(Path.Combine(AppContext.BaseDirectory, "wwwroot")))
            {
                xmlPath = Path.Combine(AppContext.BaseDirectory, "wwwroot", xmlFile);
            }
            else
            {
                xmlPath = Path.Combine(AppContext.BaseDirectory, string.Empty, xmlFile);
            }
            cfg.IncludeXmlComments(xmlPath);
        });
        return services;
    }
}
