using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployerPortal.API.Migrations
{
    public partial class IdentityCoreRolesSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44b0d967-4baf-4090-9a68-5bd2ebff324e", "24017a9c-26bf-4512-97c3-7eea4b40c1e3", "Administrator", "ADMINISTRATOR" },
                    { "383b257b-8f92-415b-9496-099f28b264f1", "f269852d-2d17-49d7-a328-308ea619aafd", "Employer", "EMPLOYER" },
                    { "04465d65-25e0-4e43-8f55-aa1438d8a031", "81db6da6-48a1-4c1f-8a0e-9dc5b0eaf18c", "RelationshipManager", "RELATIONSHIP MANAGER" },
                    { "315f2899-26e5-444f-83e8-6669bea91367", "7b3537a8-ffc9-4c48-8e9a-78da180bd383", "Supervisor", "SUPERVISOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04465d65-25e0-4e43-8f55-aa1438d8a031");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "315f2899-26e5-444f-83e8-6669bea91367");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "383b257b-8f92-415b-9496-099f28b264f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44b0d967-4baf-4090-9a68-5bd2ebff324e");
        }
    }
}
