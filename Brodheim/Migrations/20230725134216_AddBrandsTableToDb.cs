using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BrodheimDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandsTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageBrand = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "ImageBrand" },
                values: new object[,]
                {
                    { 1, "" },
                    { 2, "" },
                    { 3, "" },
                    { 4, "" },
                    { 5, "" },
                    { 6, "" },
                    { 7, "" },
                    { 8, "" },
                    { 9, "" },
                    { 10, "" },
                    { 11, "" },
                    { 12, "" },
                    { 13, "" },
                    { 14, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
