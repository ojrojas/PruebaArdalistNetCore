using Application.Commons.Constants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Application.Api.Extensions
{
    /// <summary>
    /// SwaggerGen Configration services
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>10/07/2021</date>
    internal static class SwaggerExtensions
    {
        internal static IServiceCollection AddSwaggerGenDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Application Prueba", Version = "v1" });
                c.AddSecurityDefinition(ApisConstants.JwtSchema, new OpenApiSecurityScheme()
                {
                    Name = ApisConstants.Authorization,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = ApisConstants.JwtSchema,
                    BearerFormat = ApisConstants.JwtFormat,
                    In = ParameterLocation.Header,
                    Description = ApisConstants.DescriptionJwt,
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = ApisConstants.JwtSchema
                                }
                            },
                            new string[] {}
                    }
                });
                c.EnableAnnotations();
            });

            return services;
        }
    }
}
