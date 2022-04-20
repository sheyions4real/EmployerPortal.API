using EmployerPortal.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
