using EmployerPortal.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployerPortal.API.Configurations.Entities
{
    public class RelationshipManagerSeedConfiguration : IEntityTypeConfiguration<RelationshipManager>
    {
        public void Configure(EntityTypeBuilder<RelationshipManager> builder)
        {
            builder.HasData(

                  new RelationshipManager
                  {
                      Id = 1,
                      Title = "Mr",
                      Surname = "Adetula",
                      Firstname = "Omololu",
                      Othernames = "Olasupo",
                      Gender = "M",
                      Mobile_Phone = "08029510718",
                      Email = "lolua@oakpensions.com",
                      AgentCode = "LAG101",
                      BranchCode = "LA",
                      StateOfPosting = "LA"
                  }



             );
        }

       
    }
}
