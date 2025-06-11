using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkforceAnalyticsDashboard.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentRelationToJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Jobs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_DepartmentID",
                table: "Jobs",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Departments_DepartmentID",
                table: "Jobs",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Departments_DepartmentID",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_DepartmentID",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Jobs");
        }
    }
}
