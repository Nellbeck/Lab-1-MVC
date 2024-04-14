using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_1_MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    AbsenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Absences_Absences_AbsenceId",
                        column: x => x.AbsenceId,
                        principalTable: "Absences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_AbsenceId",
                table: "Absences",
                column: "AbsenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences");
        }
    }
}
