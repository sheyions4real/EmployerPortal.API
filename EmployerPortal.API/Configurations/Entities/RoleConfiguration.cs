using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployerPortal.API.Configurations.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                 new IdentityRole
                 {
                     Name = "Administrator",
                     NormalizedName = "ADMINISTRATOR"
                 },
                new IdentityRole
                {
                    Name ="Employer",
                    NormalizedName ="EMPLOYER"
                },
                new IdentityRole
                {
                    Name = "RelationshipManager",
                    NormalizedName = "RELATIONSHIP MANAGER"
                },
                 new IdentityRole
                 {
                     Name = "Supervisor",
                     NormalizedName = "SUPERVISOR"
                 }
             );
        }

       
    }
}
