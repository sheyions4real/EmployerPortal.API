using EmployerPortal.API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace EmployerPortal.API.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureIdentity( this IServiceCollection services) // use the IserviceCollection to access the service in startup.cs
        {
            // add the services with all the configurations using the builder
            var builder = services.AddIdentityCore<ApiUser>(q => q.User.RequireUniqueEmail = true);
            builder = new Microsoft.AspNetCore.Identity.IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

            // use 
            // services.ConfigureIdentity(); to add the services identity core to the startup.cs class
        }


        public static void ConfigureJWT(this IServiceCollection services, IConfiguration config)
        {
            var jwtSettings = config.GetSection("Jwt");
            var jwtKey = Environment.GetEnvironmentVariable("KEY");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });
        }

    }
}
