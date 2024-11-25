using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrodheimDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sliders",
                table: "sliders");

            migrationBuilder.RenameTable(
                name: "sliders",
                newName: "SliderTop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SliderTop",
                table: "SliderTop",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SliderTop",
                table: "SliderTop");

            migrationBuilder.RenameTable(
                name: "SliderTop",
                newName: "sliders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sliders",
                table: "sliders",
                column: "ID");
        }
    }
}
