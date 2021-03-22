using Application.Core;
using Application.Main;
using Application.Repositories;
using Main.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Api.Extensions
{
    /// <summary>
    /// Add Services applications repositories and business
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    internal static class DIApplication
    {
        /// <summary>
        /// Add injection services
        /// </summary>
        /// <param name="services">instance services</param>
        /// <returns>services instace + services application</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        internal static IServiceCollection AddServiceInjection(this IServiceCollection services)
        {
            services.AddScoped<IEncryptedPassword, EncryptedPassword>();
            services.AddScoped<ITokenClaims, TokenClaims>();
            services.AddScoped<ILoginBusinessLogic, LoginBusinessLogic>();
            services.AddScoped<IUserBusinessLogic, UserBusinessLogic>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
