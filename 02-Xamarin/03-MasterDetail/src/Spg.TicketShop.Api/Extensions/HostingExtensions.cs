using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Spg.TicketShop.Api.Services;
using Spg.TicketShop.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spg.TicketShop.Api.Extensions
{
    public static class HostingExtensions
    {
        /// <summary>
        /// Hier wird der vom OR-Mapper erstellte Datenbank-Kontext (hier heißt sie <code>RepositoryContext</code>)
        /// in den Dependency-Injection-Kontainer mit <code>AddDbContext</code>geladen.
        /// In dieser Codezeile ändert sich nur der Parameter in MigrationsAssembly.
        /// Diese Methode wird in<code>Spg.TicketShop.Api.Startup</code>, in der Methode
        /// <code>ConfigureServices</code> aufegrufen.
        /// Siehe <see cref="Spg.TicketShop.Api.Startup"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        public static void ConfigureSqlServer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RepositoryContext>(builder => builder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString, options => options.MigrationsAssembly("Spg.TicketShop.DomainModel")));
        }

        /// <summary>
        /// Hier wird API-Seitig die Authentication konfiguriert. 
        /// Diese Methode kann so immer verwendet werden. 
        /// Kurze Erklärung:
        /// Es wird ain JWT-Token verwendet (Json Web Token), daher die Methode: <code>AddJwtBearer</code>.
        /// Darim ist die Konfigurationdes Tokens abgebildet. Danach kann JEDER Controller 
        /// in der gesamten API diesen JWT-Token überprüfen, eíndem man über die entsprechende
        /// Methode in der Controller-Klasse <code>[Authorize]</code> schriebt.
        /// Der JWT-Token muss dazu natürlich vom Client an die API im HTTP-Header gegeben werden.
        /// Siehe <see cref="Spg.TicketShop.Api.Controllers.EventController"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="secret"></param>
        public static void ConfigureJwt(this IServiceCollection services, string secret)
        {
            byte[] key = Convert.FromBase64String(secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                // Damit der Token auch als GET Parameter in der Form ...?token=xxxx übergben
                // werden kann, reagieren wir auf den Event für ankommende Anfragen.
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = ctx =>
                    {
                        string token = ctx.Request.Query["token"];
                        if (!string.IsNullOrEmpty(token))
                            ctx.Token = ctx.Request.Query["token"];
                        return Task.CompletedTask;
                    }
                };
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        /// <summary>
        /// Hier werden alle Service-Klassen die inerhalb der API zur vefügung stehen sollen
        /// in den Dependency-Injection-Kontainer mit <code>AddScoped</code>geladen.
        /// Diese Methode wird in<code>Spg.TicketShop.Api.Startup</code>, in der Methode
        /// <code>ConfigureServices</code> aufegrufen.
        /// Siehe <see cref="Spg.TicketShop.Api.Startup"/>.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<EventService>();
            services.AddScoped<ShowService>();
        }
    }
}
