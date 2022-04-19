using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployerPortal.API.Migrations
{
    public partial class DatabaseCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    EmployerCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Officer_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity","1,1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.EmployerCode);
                });

            migrationBuilder.CreateTable(
                name: "RelationshipManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Othernames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfPosting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationshipManagers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Othernames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ssn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Of_Birth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date_Employed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Created = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Upload_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agent_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scheme_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State_Of_Posting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Client_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pin_Invalid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employers_EmployerCode",
                        column: x => x.EmployerCode,
                        principalTable: "Employers",
                        principalColumn: "EmployerCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewPaymentSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContributionMonth = table.Column<int>(type: "int", nullable: false),
                    ContributionYear = table.Column<int>(type: "int", nullable: false),
                    ScheduleAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationOfPayment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewPaymentSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewPaymentSchedules_Employers_EmployerCode",
                        column: x => x.EmployerCode,
                        principalTable: "Employers",
                        principalColumn: "EmployerCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNO = table.Column<int>(type: "int", nullable: false),
                    EmployerCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount_Processed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Refund_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Checked = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Employers_EmployerCode",
                        column: x => x.EmployerCode,
                        principalTable: "Employers",
                        principalColumn: "EmployerCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployerAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RelationshipManagerId = table.Column<int>(type: "int", nullable: true),
                    EmployerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerMobile_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerContact_Officer_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State_Of_Posting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployerAllocations_Employers_EmployerCode",
                        column: x => x.EmployerCode,
                        principalTable: "Employers",
                        principalColumn: "EmployerCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployerAllocations_RelationshipManagers_RelationshipManagerId",
                        column: x => x.RelationshipManagerId,
                        principalTable: "RelationshipManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployerCode",
                table: "Employees",
                column: "EmployerCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerAllocations_EmployerCode",
                table: "EmployerAllocations",
                column: "EmployerCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerAllocations_RelationshipManagerId",
                table: "EmployerAllocations",
                column: "RelationshipManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_NewPaymentSchedules_EmployerCode",
                table: "NewPaymentSchedules",
                column: "EmployerCode");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_EmployerCode",
                table: "Schedules",
                column: "EmployerCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmployerAllocations");

            migrationBuilder.DropTable(
                name: "NewPaymentSchedules");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "RelationshipManagers");

            migrationBuilder.DropTable(
                name: "Employers");
        }
    }
}
