using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spg.TicketShop.Api.Extensions;
using Spg.TicketShop.DomainModel;

namespace Spg.TicketShop.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <remarks>
        /// Diese Methode muss erweitert werden um:
        /// <code>ConfigureSqlServer</code>
        /// <code>ConfigureJwt</code>
        /// <code>ConfigureServices</code>
        /// </remarks>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSqlServer($"{Configuration["AppSettings:Database"]}");
            services.ConfigureJwt(Configuration["AppSettings:Secret"]);
            services.ConfigureServices();

            services.AddControllers();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <remarks>
        /// Diese Methode kann so übernommen werden.
        /// </remarks>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Wird ASPNETCORE_ENVIRONMENT: Development bei environmentVariables gesetzt, wird
            // bei einer Fehlermeldung ein Stacktrace ausgegeben.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Das Routing aktivieren.
            app.UseRouting();

            // Muss NACH UseRouting() und VOR UseEndpoints() stehen.
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization();

            // Die in services.AddControllers() geladenen Controller als Endpunkte des Routings registrieren.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
