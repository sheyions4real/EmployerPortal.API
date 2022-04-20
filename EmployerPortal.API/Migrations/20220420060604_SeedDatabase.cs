using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployerPortal.API.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployerAllocations_RelationshipManagers_RelationshipManagerId",
                table: "EmployerAllocations");

            migrationBuilder.RenameColumn(
                name: "RelationshipManagerId",
                table: "EmployerAllocations",
                newName: "RelationshipManagerID");

            migrationBuilder.RenameIndex(
                name: "IX_EmployerAllocations_RelationshipManagerId",
                table: "EmployerAllocations",
                newName: "IX_EmployerAllocations_RelationshipManagerID");

            migrationBuilder.AlterColumn<double>(
                name: "Refund_Amount",
                table: "Schedules",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Amount_Processed",
                table: "Schedules",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Schedules",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "StatusCode",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RelationshipManagerID",
                table: "EmployerAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Officer_Position",
                table: "EmployerAllocations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "EmployerCode", "Address", "City", "Contact_Officer_Name", "CreatedBy", "DateCreated", "DateModified", "Email", "EmployerName", "Id", "Industry", "Mobile_Phone", "ModifiedBy", "Sector", "State" },
                values: new object[,]
                {
                    { "PR0000613584", "15B OKO AWO STREET  VICTORIA ISLAND, LAGOS", "LAGOS", "Akinwumi A.", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@oakpensions.com", "OAK PENSIONS LIMITED", 1, "Finance", "07002255625", null, "Private", "LAGOS" },
                    { "PR0000041041", "PLOT 590 ZONE A.O NAIC HOUSE CBD", "Abuja", "AYEKAME ELUKPO", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "DUETHEL PRO SERVICES LIMITED", 2, "Finance", "08126696169", null, "Private", "FCT" },
                    { "PR0000041042", "16 YASHIM DOGARA CRESCENT DAWAKI ABUJA", "Abuja", "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "WINCREST CONSULT LIMITED", 3, "Finance", "08163313858", null, "Private", "FCT" }
                });

            migrationBuilder.InsertData(
                table: "RelationshipManagers",
                columns: new[] { "Id", "AgentCode", "BranchCode", "CreatedBy", "DateCreated", "DateModified", "Email", "Firstname", "Gender", "Mobile_Phone", "ModifiedBy", "Othernames", "StateOfPosting", "Surname", "Title" },
                values: new object[] { 1, "LAG101", "LA", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lolua@oakpensions.com", "Omololu", "M", "08029510718", null, "Olasupo", "LA", "Adetula", "Mr" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Agent_Code", "Client_Status", "CreatedBy", "DateCreated", "DateModified", "Date_Created", "Date_Employed", "Date_Of_Birth", "Email", "EmployerCode", "EmployerName", "Firstname", "Gender", "Mobile_Phone", "ModifiedBy", "Othernames", "Pin", "Pin_Invalid", "Scheme_Id", "Ssn", "State_Of_Posting", "Surname", "Title", "Upload_Date" },
                values: new object[] { 1, "", "C", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2012-04-01", "2012-04-01", "1986-10-26", "sheyions4real@yahoo.co.uk", "PR0000613584", "OAK PENSIONS LIMITED", "Sheyi", "M", "08134454808", null, "Matthew", "PEN100599222817", "0", "2000006", "", "LA", "Omagene", "Mr", "2012-04-01" });

            migrationBuilder.InsertData(
                table: "EmployerAllocations",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "EmployerAddress", "EmployerCity", "EmployerCode", "EmployerContact_Officer_Name", "EmployerEmail", "EmployerMobile_Phone", "EmployerState", "ModifiedBy", "Officer_Position", "RelationshipManagerID", "State_Of_Posting" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "266 Murtala Muhammed Way, Alagomeji Yaba", "Lagos", "PR0000613584", "Henry Christopher", "info@oakpensions.com", "07002255625", "LA", null, "Head, HR", 1, "LA" });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "Amount", "Amount_Processed", "Checked", "CreatedBy", "DateCreated", "DateModified", "Description", "EmployerCode", "IDNO", "ModifiedBy", "RefNo", "Refund_Amount", "StatusCode", "ValueDate" },
                values: new object[] { 1, 2021556.46, 0.0, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REM  N-10042361295/PR0000613584/NIP0341903290-000000364600 91004236129", "PR0000613584", 200734, null, "S50268032-2", 0.0, "R", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1987) });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployerAllocations_RelationshipManagers_RelationshipManagerID",
                table: "EmployerAllocations",
                column: "RelationshipManagerID",
                principalTable: "RelationshipManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployerAllocations_RelationshipManagers_RelationshipManagerID",
                table: "EmployerAllocations");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployerAllocations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "EmployerCode",
                keyValue: "PR0000041041");

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "EmployerCode",
                keyValue: "PR0000041042");

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "EmployerCode",
                keyValue: "PR0000613584");

            migrationBuilder.DeleteData(
                table: "RelationshipManagers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Officer_Position",
                table: "EmployerAllocations");

            migrationBuilder.RenameColumn(
                name: "RelationshipManagerID",
                table: "EmployerAllocations",
                newName: "RelationshipManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployerAllocations_RelationshipManagerID",
                table: "EmployerAllocations",
                newName: "IX_EmployerAllocations_RelationshipManagerId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Refund_Amount",
                table: "Schedules",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount_Processed",
                table: "Schedules",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Schedules",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "RelationshipManagerId",
                table: "EmployerAllocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployerAllocations_RelationshipManagers_RelationshipManagerId",
                table: "EmployerAllocations",
                column: "RelationshipManagerId",
                principalTable: "RelationshipManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
