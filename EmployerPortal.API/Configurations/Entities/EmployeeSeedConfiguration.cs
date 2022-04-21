using EmployerPortal.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployerPortal.API.Configurations.Entities
{
    public class EmployeeSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(

                  new Employee
                  {
                      Id = 1,
                      Pin = "PEN100599222817",
                      Title = "Mr",
                      Surname = "Omagene",
                      Firstname = "Sheyi",
                      Othernames = "Matthew",
                      Gender = "M",
                      Ssn = "",
                      Date_Of_Birth = "1986-10-26",
                      Mobile_Phone = "08134454808",
                      Email = "sheyions4real@yahoo.co.uk",
                      EmployerName = "OAK PENSIONS LIMITED",
                      EmployerCode = "PR0000613584",
                      Date_Employed = "2012-04-01",
                      Date_Created = "2012-04-01",
                      Upload_Date = "2012-04-01",
                      Agent_Code = "",
                      Scheme_Id = "2000006",
                      State_Of_Posting = "LA",
                      Client_Status = "C",
                      Pin_Invalid = "0"
                  }



             );
        }
    }
}
