using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPostingBrowser.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobDetailsSet",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployerId = table.Column<int>(type: "INTEGER", nullable: true),
                    EmployerName = table.Column<string>(type: "TEXT", nullable: true),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: true),
                    LocationName = table.Column<string>(type: "TEXT", nullable: true),
                    MinimumSalary = table.Column<double>(type: "REAL", nullable: true),
                    MaximumSalary = table.Column<double>(type: "REAL", nullable: true),
                    DatePosted = table.Column<string>(type: "TEXT", nullable: true),
                    ExternalUrl = table.Column<string>(type: "TEXT", nullable: true),
                    JobUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ContractType = table.Column<string>(type: "TEXT", nullable: true),
                    JobDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ApplicationCount = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDetailsSet", x => x.JobId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobDetailsSet");
        }
    }
}
