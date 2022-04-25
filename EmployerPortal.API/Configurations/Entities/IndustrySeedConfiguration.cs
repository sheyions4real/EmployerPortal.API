using EmployerPortal.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployerPortal.API.Configurations.Entities
{
    public class IndustrySeedConfiguration : IEntityTypeConfiguration<Industry>
    {
        public void Configure(EntityTypeBuilder<Industry> builder)
        {
            builder.HasData(
                 new Industry
                 {
                     Name = "Petroleum Products Sales and Services",
                     Description = "Petroleum Products Sales and Services",
                     Code = ""
                 },
                 new Industry
                 {
                     Name = "Others",
                     Description = "Other services not listed",
                     Code = ""
                 }

             );
        }

       
    }
}
