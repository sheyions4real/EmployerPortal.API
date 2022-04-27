using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployerPortal.Data.Configurations.Entities
{
    public class StateSeedConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasData(
                 new State
                 {
                     Code = "AB",
                     Description = "ABIA",
                     ZoneCode = "SE",
                     Region = "SOUTH EAST"
                 },
                 new State
                 {
                     Code = "AD",
                     Description = "ADAMAWA",
                     ZoneCode = "NE",
                     Region = "KANO"
                 },
                 new State
                 {
                     Code = "AK",
                     Description = "AKWA IBOM",
                     ZoneCode = "SS",
                     Region = "AKWA IBOM"
                 },
                 new State
                 {
                     Code = "AN",
                     Description = "ANAMBRA",
                     ZoneCode = "SE",
                     Region = "SOUTH EAST"
                 },
                 new State
                 {
                     Code = "BA",
                     Description = "BAUCH",
                     ZoneCode = "NW",
                     Region = "KADUNA"
                 },
                 new State
                 {
                     Code = "BE",
                     Description = "BENUE",
                     ZoneCode = "NC",
                     Region = "BENUE"
                 },
                 new State
                 {
                     Code = "BO",
                     Description = "BORNO",
                     ZoneCode = "NE",
                     Region = "KANO"
                 },
                 new State
                 {
                     Code = "BY",
                     Description = "BAYELSA",
                     ZoneCode = "SS",
                     Region = "RIVERS"
                 },
                 new State
                 {
                     Code = "CR",
                     Description = "CROSS RIVER",
                     ZoneCode = "SS",
                     Region = "AKWA IBOM"
                 },
                 new State
                 {
                     Code = "DT",
                     Description = "DELTA",
                     ZoneCode = "SS",
                     Region = "DELTA"
                 },
                 new State
                 {
                     Code = "EB",
                     Description = "EBONYI",
                     ZoneCode = "SE",
                     Region = "SOUTH EAST"
                 },
                 new State
                 {
                     Code = "ED",
                     Description = "EDO",
                     ZoneCode = "SS",
                     Region = "DELTA"
                 },
                 new State
                 {
                     Code = "EK",
                     Description = "EKITI",
                     ZoneCode = "SW",
                     Region = "EKITI"
                 },
                 new State
                 {
                     Code = "EN",
                     Description = "ENUGU",
                     ZoneCode = "SE",
                     Region = "SOUTH EAST"
                 },
                 new State
                 {
                     Code = "FC",
                     Description = "FED. CAPITAL TERITORY",
                     ZoneCode = "FC",
                     Region = "ABUJA"
                 },
                 new State
                 {
                     Code = "GB",
                     Description = "GOMBE",
                     ZoneCode = "NW",
                     Region = "KANO"
                 },
                 new State
                 {
                     Code = "IM",
                     Description = "IMO",
                     ZoneCode = "SE",
                     Region = "SOUTH EAST"
                 },
                 new State
                 {
                     Code = "JG",
                     Description = "JIGAWA",
                     ZoneCode = "NW",
                     Region = "KANO"
                 },
                 new State
                 {
                     Code = "KB",
                     Description = "KEBBI",
                     ZoneCode = "NW",
                     Region = "KANO"
                 },
                 new State
                 {
                     Code = "KD",
                     Description = "ABIA",
                     ZoneCode = "SE",
                     Region = "KADUNA"
                 },
                 new State
                 {
                     Code = "KG",
                     Description = "ABIA",
                     ZoneCode = "NV",
                     Region = "BENUE"
                 },
                 new State
                 {
                     Code = "KN",
                     Description = "KANO",
                     ZoneCode = "NW",
                     Region = "KANO"
                 },
                 new State
                 {
                     Code = "KT",
                     Description = "KATSINA",
                     ZoneCode = "NW",
                     Region = "KANO"
                 },
                 new State
                 {
                     Code = "KW",
                     Description = "KWARA",
                     ZoneCode = "NC",
                     Region = "OSUN"
                 },
                 new State
                 {
                     Code = "LA",
                     Description = "LAGOS",
                     ZoneCode = "SW",
                     Region = "LAGOS"
                 },
                 new State
                 {
                     Code = "NG",
                     Description = "NIGER",
                     ZoneCode = "NE",
                     Region = "BENUE"
                 },
                 new State
                 {
                     Code = "NR",
                     Description = "NASARAWA",
                     ZoneCode = "NC",
                     Region = "BENUE"
                 },
                 new State
                 {
                     Code = "OD",
                     Description = "ONDO",
                     ZoneCode = "SW",
                     Region = "EKITI"
                 },
                 new State
                 {
                     Code = "OG",
                     Description = "OGUN",
                     ZoneCode = "SW",
                     Region = "OGUN"
                 },
                 new State
                 {
                     Code = "OS",
                     Description = "OSUN",
                     ZoneCode = "SW",
                     Region = "OSUN"
                 },
                 new State
                 {
                     Code = "OY",
                     Description = "OYO",
                     ZoneCode = "SW",
                     Region = "OYO"
                 },
                 new State
                 {
                     Code = "PL",
                     Description = "PLATEAU",
                     ZoneCode = "NC",
                     Region = "KADUNA"
                 },
                 new State
                 {
                     Code = "RV",
                     Description = "RIVERS",
                     ZoneCode = "SS",
                     Region = "RIVERS"
                 },
                 new State
                 {
                     Code = "SO",
                     Description = "SOKOTO",
                     ZoneCode = "NE",
                     Region = "KANO"
                 },
                 new State
                 {
                     Code = "TB",
                     Description = "TARABA",
                     ZoneCode = "SE",
                     Region = "KANO"
                 },
                 new State
                 {
                     Code = "YB",
                     Description = "YOBE",
                     ZoneCode = "NW",
                     Region = "KANO"
                 },
                 new State
                 {
                     Code = "ZA",
                     Description = "ZAMFARA",
                     ZoneCode = "NE",
                     Region = "KANO"
                 }




             );
        }


    }
}
