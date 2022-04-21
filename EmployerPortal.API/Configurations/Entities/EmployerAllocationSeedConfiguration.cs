using EmployerPortal.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployerPortal.API.Configurations.Entities
{
    public class EmployerAllocationSeedConfiguration : IEntityTypeConfiguration<EmployerAllocation>
    {
        public void Configure(EntityTypeBuilder<EmployerAllocation> builder)
        {

            builder
          .HasData(
              new EmployerAllocation
              {
                  Id = 1,
                  EmployerCode = "PR0000613584",
                  RelationshipManagerID = 1,
                  EmployerAddress = "266 Murtala Muhammed Way, Alagomeji Yaba",
                  EmployerCity = "Lagos",
                  EmployerState = "LA",
                  EmployerMobile_Phone = "07002255625",
                  EmployerEmail = "info@oakpensions.com",
                  EmployerContact_Officer_Name = "Henry Christopher",
                  Officer_Position = "Head, HR",
                  State_Of_Posting = "LA",
              }
            );

        }
    }
}
