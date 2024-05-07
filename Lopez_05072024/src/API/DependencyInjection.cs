using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace API;

public static class DependencyInjection
{
    public static IServiceCollection AddWebAPIServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
            //        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "File API",
                Version = "v1",
                Description = "File API"
            });
        });

        return services;
    }
}
