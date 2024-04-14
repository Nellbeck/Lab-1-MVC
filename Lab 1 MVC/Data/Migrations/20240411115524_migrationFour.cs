using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_1_MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class migrationFour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Absences_AbsenceId",
                table: "Absences");

            migrationBuilder.RenameColumn(
                name: "AbsenceId",
                table: "Absences",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Absences_AbsenceId",
                table: "Absences",
                newName: "IX_Absences_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Employees_EmployeeId",
                table: "Absences",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Employees_EmployeeId",
                table: "Absences");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Absences",
                newName: "AbsenceId");

            migrationBuilder.RenameIndex(
                name: "IX_Absences_EmployeeId",
                table: "Absences",
                newName: "IX_Absences_AbsenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Absences_AbsenceId",
                table: "Absences",
                column: "AbsenceId",
                principalTable: "Absences",
                principalColumn: "Id");
        }
    }
}
