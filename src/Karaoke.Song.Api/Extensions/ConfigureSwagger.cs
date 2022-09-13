using Microsoft.OpenApi.Models;

namespace Karaoke.Song.Api.Extensions
{
    public static class ConfigureSwagger
    {
        public static void AddSwaggerGenConfigured(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                Uri uriServices = new Uri("https://example.com/terms");
                OpenApiContact contact = new OpenApiContact
                {
                    Name = "Contact",
                    Url = new Uri("https://example.com/contact")
                };
                OpenApiLicense license = new OpenApiLicense
                {
                    Name = "License",
                    Url = new Uri("https://example.com/license")
                };


                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "Karaoke.Song.Api",
                    Description = "API para la aplicación de Karaoke",
                    TermsOfService = uriServices,
                    Contact = contact,
                    License = license
                });

                options.SwaggerDoc("v1.1", new OpenApiInfo
                {
                    Version = "v1.1",
                    Title = "Karaoke.Song.Api",
                    Description = "API para la aplicación de Karaoke",
                    TermsOfService = uriServices,
                    Contact = contact,
                    License = license
                });

                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        public static void UseSwaggerUIConfigured(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", "Karaoke.Song.Api V1.0");
                options.SwaggerEndpoint($"/swagger/v1.1/swagger.json", "Karaoke.Song.Api V1.1");
            });
        }
    }
}
