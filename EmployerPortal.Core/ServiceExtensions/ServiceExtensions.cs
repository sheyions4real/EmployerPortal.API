using AspNetCoreRateLimit;
using EmployerPortal.Data;
using EmployerPortal.Core.DTOs;
using Marvin.Cache.Headers;
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
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using EmployerPortal.Core.Configurations;
using System.Reflection;
using EmployerPortal.Core.Models;

namespace EmployerPortal.Core.ServiceExtensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureIdentity(this IServiceCollection services) // use the IserviceCollection to access the service in startup.cs
        {
            // add the services with all the configurations using the builder
            var builder = services.AddIdentityCore<ApiUser>(q => q.User.RequireUniqueEmail = true);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddTokenProvider("EmployerPortal.API", typeof(DataProtectorTokenProvider<ApiUser>));
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
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    // use the configuration Editor of the Application on the  InetManager of the server
                    // under Section change to system.webServer/aspNetCore Add the Enviromental Variable to the property
                    // ensure the From is ApplicationHost.config <location path ...> 
                    // Add the Enviromental Variable here
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("Key").Value))
                };
            });
        }




        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            // override the default exception handler
            app.UseExceptionHandler(
                error =>
                {
                    error.Run(async context =>
                            {   // context here is the controller sending the error
                                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                                context.Response.ContentType = "application/json";
                                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                                if (contextFeature != null)
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
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.ApiVersionReader = new HeaderApiVersionReader("api-version"); // enable the client add the the api-version in the request header
            });
        }





        // configure marvin caching
        public static void ConfigureHttpCacheHeaders(this IServiceCollection services)
        {
            services.AddResponseCaching();
            services.AddHttpCacheHeaders(
                (expirationOpt) =>
                {
                    expirationOpt.MaxAge = 65; // configure the maxage of the caching
                    expirationOpt.CacheLocation = CacheLocation.Private;

                }, (validationOpt) =>
                 {
                     validationOpt.MustRevalidate = true;
                 }
                );
          
        }


        // configure throtting
        public static void ConfigureRateLimiting(this IServiceCollection services)
        {
            var rateLimitRules = new List<RateLimitRule>
            {   // SPECIFY Rules for all endpoint
                new RateLimitRule
                {
                    Endpoint = "*",
                    Limit= 10,       // 100 call every 5 sec
                    Period = "30s"      // 10 calls for 30 sec
                }
            };
            services.Configure<IpRateLimitOptions>(opt =>
            {
                opt.GeneralRules = rateLimitRules;
            });
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }




        public static void ConfigureSwaggerDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "0auth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
           // services.AddAutoMapper(typeof(MapperInitializer));  // you can use this or
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); // this will automatically fectch the automapper configuration from the .Core Project.
                                                                     // //can add multiple configuration automtically
            
           
        }


    }
}
