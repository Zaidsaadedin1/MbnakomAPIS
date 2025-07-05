using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MbnakomAPIS.Migrations
{
    /// <inheritdoc />
    public partial class change_appointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MedicalHistory",
                table: "Appointments",
                newName: "PropertyType");

            migrationBuilder.RenameColumn(
                name: "Concerns",
                table: "Appointments",
                newName: "ProjectDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropertyType",
                table: "Appointments",
                newName: "MedicalHistory");

            migrationBuilder.RenameColumn(
                name: "ProjectDetails",
                table: "Appointments",
                newName: "Concerns");
        }
    }
}
