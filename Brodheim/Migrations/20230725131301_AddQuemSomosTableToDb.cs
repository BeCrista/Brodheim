using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BrodheimDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddQuemSomosTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuemSomos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRepresentative = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityRepresentative = table.Column<int>(type: "int", nullable: false),
                    ImageRepresentative = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuemSomos", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "QuemSomos",
                columns: new[] { "ID", "ImageRepresentative", "NameRepresentative", "QuantityRepresentative" },
                values: new object[,]
                {
                    { 1, "", "Colaboradores", 600 },
                    { 2, "", "Lojas", 70 },
                    { 3, "", "Marcas", 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuemSomos");
        }
    }
}
