using System;

namespace ischool_backend.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

    //TODO: IIS
    public static void ConfigureIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options =>
        {

        });
}
