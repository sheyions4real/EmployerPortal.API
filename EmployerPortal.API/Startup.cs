using EmployerPortal.API.Configurations;
using EmployerPortal.API.Data;
using EmployerPortal.API.Extensions;
using EmployerPortal.API.IRepository;
using EmployerPortal.API.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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



            services.AddControllers();

            services.AddCors(policy =>
            {
                // define what will be allowed to be assesed (headers, methods, origin, etc)
                policy.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });

            services.AddAutoMapper(typeof(MapperInitializer));



            // Dependency Injection
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            // to resolve cyclic dependency issue
            // install Microsoft.aspnetcore.mvc.Newtonsoft package
            // this is specifying that ignore where u see the cyclic dependency issue

            services.AddControllers()
                .AddNewtonsoftJson(
                op => op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             );

            // IdentityUser
            // add identity core to our services API
            services.AddAuthentication();
            services.ConfigureIdentity();    // this is coming from our custom ServicesExtensions class with configuration




            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployerPortal.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployerPortal.API v1"));


            app.UseSerilogRequestLogging();
            app.UseStaticFiles();


            app.UseHttpsRedirection();
            app.UseCors("AllowAll");


            app.UseRouting();

            app.UseAuthorization();

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
