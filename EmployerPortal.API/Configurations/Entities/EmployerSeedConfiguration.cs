using EmployerPortal.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployerPortal.API.Configurations.Entities
{
    public class EmployerSeedConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.HasData(

                new Employer
                {
                    Id = 1,
                    EmployerCode = "PR0000613584",
                    EmployerName = "OAK PENSIONS LIMITED",
                    Address = "15B OKO AWO STREET  VICTORIA ISLAND, LAGOS",
                    City = "LAGOS",
                    State = "LAGOS",
                    Mobile_Phone = "07002255625",
                    Email = "info@oakpensions.com",
                    Contact_Officer_Name = "Akinwumi A.",
                    Sector = "Private",
                    Industry = "Finance"
                },
                new Employer
                {
                    Id = 2,
                    EmployerCode = "PR0000041041",
                    EmployerName = "DUETHEL PRO SERVICES LIMITED",
                    Address = "PLOT 590 ZONE A.O NAIC HOUSE CBD",
                    City = "Abuja",
                    State = "FCT",
                    Mobile_Phone = "08126696169",
                    Email = "",
                    Contact_Officer_Name = "AYEKAME ELUKPO",
                    Sector = "Private",
                    Industry = "Finance"


                },
                new Employer
                {
                    Id = 3,
                    EmployerCode = "PR0000041042",
                    EmployerName = "WINCREST CONSULT LIMITED",
                    Address = "16 YASHIM DOGARA CRESCENT DAWAKI ABUJA",
                    City = "Abuja",
                    State = "FCT",
                    Mobile_Phone = "08163313858",
                    Email = "",
                    Contact_Officer_Name = "",
                    Sector = "Private",
                    Industry = "Finance"
                }


             );
        }
    }
}
