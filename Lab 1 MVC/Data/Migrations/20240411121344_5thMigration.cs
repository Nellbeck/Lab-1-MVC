using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_1_MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class _5thMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valid",
                table: "Absences");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Absences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Absences");

            migrationBuilder.AddColumn<bool>(
                name: "Valid",
                table: "Absences",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
