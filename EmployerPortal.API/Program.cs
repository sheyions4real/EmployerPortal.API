using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployerPortal.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // let the application knows to use the serilog in place of the default logger
            // initialize the Seri logger for it to write to file with all parameters

            // the logger can also be initialized in the Startup File

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                    path: "c:\\EmployerPortal\\Logs\\log-.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information
                )
                .WriteTo.File(
                    path: "./logs/log-.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information
                )
                .WriteTo.Seq(
                        serverUrl: "http://localhost:5341",
                    apiKey: "Z4RfJKlLT4v02gAcOYDo", //          "HUSx1iDgXY6xGSodt4MN",
                   restrictedToMinimumLevel: LogEventLevel.Verbose
                )
                .CreateLogger();

            try
            {
                Log.Information("Application Is Starting");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception)
            {

                Log.Fatal("Application Failed to Start");
            }
            finally
            {
                Log.CloseAndFlush();
            }
           // CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()               // use the logger created in the main method
            //.UseSerilog((ctx, lc) =>
            //lc.WriteTo.Console()
            //.ReadFrom.Configuration(ctx.Configuration)) // Configuration for Serilog in app.settings                                  // let the application knows to use the serilog in place of the default logger
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
