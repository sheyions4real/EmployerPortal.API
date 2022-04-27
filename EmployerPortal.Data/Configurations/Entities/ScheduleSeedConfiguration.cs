using EmployerPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EmployerPortal.Data.Configurations.Entities
{
    public class ScheduleSeedConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
      
            builder
                .HasData(

                    new Schedule
                    {
                        Id = 1,
                        IDNO = 200734,
                        EmployerCode = "PR0000613584",
                        EmployerId = 1,
                        RefNo = "S50268032-2",
                        Amount = 2021556.46,
                        Amount_Processed = 0.00,
                        Refund_Amount = 0.00,
                        Description = "REM  N-10042361295/PR0000613584/NIP0341903290-000000364600 91004236129",
                        ValueDate = new DateTime(2019 - 03 - 29),
                        Checked = false,
                        StatusCode = "R"
                    }
                



             );
        }
    }
}
