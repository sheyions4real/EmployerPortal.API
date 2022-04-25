using EmployerPortal.API.Data;
using EmployerPortal.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
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
            Console.WriteLine(jwtKey);
            Console.WriteLine(jwtSettings);


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




        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            // override the default exception handler
            app.UseExceptionHandler(
                error => {
                    error.Run(async context =>
                            {   // context here is the controller sending the error
                                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                                context.Response.ContentType = "application/json";
                                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                             
                                if(contextFeature != null)
                                {
                                    Log.Error($"Something Went Wrong in the {contextFeature.Error}");
                                    await context.Response.WriteAsync(new Error
                                        {
                                            StatusCode = context.Response.StatusCode,
                                            Message = "Internal Server Error. Please Try Again Later."
                                        }.ToString() 
                                    );
                                }
                            });
                });
        }



        // configure versioning on out API
        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(option =>
            {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified= true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.ApiVersionReader = new HeaderApiVersionReader("api-version"); // enable the client add the the api-version in the request header
            });
        }



    }
}
