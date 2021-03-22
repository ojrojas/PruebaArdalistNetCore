using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Api.Extensions
{
    internal static class AddCorsExtensions
    {
        internal static IServiceCollection AddCorExtensions(this IServiceCollection services)
        {
            return services.AddCors(option => {
                option.AddPolicy("PruebaTecnica", policy => {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }
    }
}
