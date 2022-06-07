using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobs.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CVs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedSalary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacancyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLogged = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredExperience = table.Column<int>(type: "int", nullable: false),
                    RequiredSkills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsLogged", "PasswordHash", "Name" },
                values: new object[,]
                {
                    { 1, "administrator@mail.com", true, "CF-83-5D-E3-D4-EA-01-36-7C-45-E4-12-E7-A9-39-3A-85-A4-E4-0A-F1-49-ED-8C-3E-D6-C3-7C-05-B6-7B-27-81-3D-7F-F8-07-2C-10-35-CE-DD-19-41-5A-DF-17-12-8D-63-18-6F-05-F0-D6-56-00-2B-0C-A1-C3-4F-44-A0", "Administrator" },
                    { 2, "recruiter@mail.com", false, "C5-C8-DE-47-3B-78-8E-10-7E-89-F3-17-F3-3F-D5-C7-86-97-C5-AB-2F-C4-AC-1C-F0-44-DB-E4-15-CC-28-03-95-6E-E5-91-CF-4B-8E-27-D2-D1-7E-DA-D1-18-01-F7-F7-91-85-79-A8-B5-DE-E5-24-E8-29-03-BE-C1-87-CE", "Recruiter" },
                    { 3, "user@mail.com", false, "B1-43-61-40-4C-07-8F-FD-54-9C-03-DB-44-3C-3F-ED-E2-F3-E5-34-D7-3F-78-F7-73-01-ED-97-D4-A4-36-A9-FD-9D-B0-5E-E8-B3-25-C0-AD-36-43-8B-43-FE-C8-51-0C-20-4F-C1-C1-ED-B2-1D-09-41-C0-0E-9E-2C-1C-E2", "User" }
                });

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Id", "Name", "Position", "RequiredExperience", "RequiredSkills", "Salary", "StartDate" },
                values: new object[,]
                {
                    { 1, ".Net Traineeship", "Trainee software engineer", 0, ".Net, C#, OOP, SQL", 400.0, new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, ".Net Junior", "Junior software engineer", 1, ".Net, C#, OOP, SQL, ASP.NET, .Net Core, React", 800.0, new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVs");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vacancies");
        }
    }
}