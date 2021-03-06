using AspNetCoreRateLimit;
using EmployerPortal.Core.Configurations;
using EmployerPortal.Core.IRepository;
using EmployerPortal.Core.Repository;
using EmployerPortal.Core.ServiceExtensions;
using EmployerPortal.Core.Services;
using EmployerPortal.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Collections.Generic;

namespace EmployerPortal.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            // another way to set serilog to log to file
            //    // Configuration for Serilog in app.settings 
            //    Log.Logger = new LoggerConfiguration()
            //.ReadFrom.Configuration(configuration)
            //.CreateLogger();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DatabaseContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                }
            );


            // for configuration of throtting to avoid Denial of Service
            services.AddMemoryCache();
            // configure throtting from service extension
            services.ConfigureRateLimiting();
            services.AddHttpContextAccessor();

            // inject counter and rules stores
            services.AddInMemoryRateLimiting();

            //load general configuration from appsettings.json if setting configuration from the app.json file
            // services.Configure<ClientRateLimitOptions>(Configuration.GetSection("ClientRateLimiting"));

            //load client rules from appsettings.json
            //services.Configure<ClientRateLimitPolicies>(Configuration.GetSection("ClientRateLimitPolicies"));




            // enable cacheing
            //services.AddResponseCaching();
            services.ConfigureHttpCacheHeaders();


            // IdentityUser
            // add identity core to our services API
            services.AddAuthentication();
            services.ConfigureIdentity();    // this is coming from our custom ServicesExtensions class with configuration
            services.ConfigureJWT(Configuration);    // configure the JWT for the application



            services.AddCors(policy =>
            {
                // define what will be allowed to be assesed (headers, methods, origin, etc)
                policy.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });

             services.ConfigureAutoMapper();
            //services.AddAutoMapper(typeof(MapperInitializer));



            // Dependency Injection
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAuthManager, AuthManager>();   // used AddScoped because one will served one for the entire application

            // configuration (resolvers, counter key builders)
            //services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();


            //// the default swagger doc
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployerPortal.API", Version = "v1" });
            //});

            // enable swagger documentation to use the JWT token
            // AddSwaggerDoc(services);
            services.ConfigureSwaggerDoc();


            // to resolve cyclic dependency issue
            // install Microsoft.aspnetcore.mvc.Newtonsoft package
            // this is specifying that ignore where u see the cyclic dependency issue

            services.AddControllers(
                //// add global response caching
                //config =>
                //{
                //    config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
                //    {
                //        Duration = 20
                //    });
                //}
                )
                .AddNewtonsoftJson(
                op => op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             );
            // configure API Versioning. You can access different versions of the Endpoints or controller
            services.ConfigureVersioning();





        }

        //// add securitydefinition and requirement configuration to the swagger doc to enable JWT bearer authentication
        //private static void AddSwaggerDoc(IServiceCollection services)
        //{
        //    services.AddSwaggerGen(c =>
        //    {
        //        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //        {
        //            Description = @"JWT Authentication header using Bearer scheme.
        //                        Enter 'Bearer' [space] and then your token in the text input below.
        //                        Example: 'Bearer 12345abcdef",
        //            Name = "Authorization",
        //            In = ParameterLocation.Header,
        //            Type = SecuritySchemeType.ApiKey,
        //            Scheme = "Bearer"
        //        });

        //        c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
        //                    {
        //                        new OpenApiSecurityScheme
        //                        {
        //                            Reference = new OpenApiReference
        //                                    {
        //                                        Type= ReferenceType.SecurityScheme,
        //                                        Id = "Bearer"
        //                                    },
        //                            Scheme = "Oauth2",
        //                            Name = "Bearer",
        //                            In= ParameterLocation.Header,
        //                        },
        //                        new List<string>()
        //                    }
        //        });

        //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployerPortal.API", Version = "v1" });
        //    });
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseIpRateLimiting();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employer.API v1");
                // once published use this setting to match the base path of the server
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Employer.API v1");
            });

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseResponseCaching();
            app.UseHttpCacheHeaders();



            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // app.UseSwagger();
            // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployerPortal.API v1"));


            app.UseSerilogRequestLogging();
            app.UseStaticFiles();







            app.UseEndpoints(endpoints =>
            {
                //// if we want to access our endpoints by Home/Index or Home/Dashboard/1
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern : "{controller=Home}/{action=index}/{id?}"
                //    );

                // we will use the specific configurations in the Controllers
                // Attribute routing eg [Router("api/[Controller]"] 
                // api/Home/HttpVeb i.e Get or Post or Put or Delete



                endpoints.MapControllers();
            });
        }
    }
}
