using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Api.Extensions;
using Mappers.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Application.Api
{
    /// <summary>
    /// StartUp Application
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>20/03/2021</date>
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor StartUp
        /// </summary>
        /// <param name="configuration">Injection Configuration Settings Application</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            /// Add Cors 
            services.AddCorExtensions();
            /// Add AppDbContext create database code firts
            services.AddAppDbContextDatabaseSqlite(Configuration);
            /// Add services Jwt Configuration Schemma
            services.AddJwtServices(Configuration);
            /// Add services Swagger Configuration Open Api
            services.AddSwaggerGenDoc();
            /// Add Injections Services Application
            services.AddServiceInjection();
            services.AddAutoMapper(typeof(UserMappersProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
               
            }

            /// Use Configuration Endpoints Swagger
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            /// Implement Middleware Errors Exception Application
            app.UseMiddleware<ErrorMiddlewareExtensions>();

            app.UseCors("PruebaTecnica");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
