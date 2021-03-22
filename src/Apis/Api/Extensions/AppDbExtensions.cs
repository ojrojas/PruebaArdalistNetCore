using Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Api.Extensions
{
    /// <summary>
    /// Extension AppDbContext database 
    /// </summary>
    /// <author>Oscar Julian Rojas </author>
    /// <date>20/03/2021</date>
    internal static class AppDbExtensions
    {
        /// <summary>
        /// Injectable extension services Sqlite connection
        /// </summary>
        /// <param name="services">instanse service application</param>
        /// <param name="configuration">configuration settings</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        /// <returns>Configuration services</returns>
        internal static IServiceCollection AddAppDbContextDatabaseSqlite(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlite(configuration.GetConnectionString("connection"));
            });
            return services;
        }
    }
}
