using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BrodheimDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPassosTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageSlider",
                table: "SliderTop",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PersonImage",
                table: "SliderTestemunhas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageRepresentative",
                table: "QuemSomos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageBrand",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Passos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePasso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoPasso = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passos", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Passos",
                columns: new[] { "ID", "DescricaoPasso", "ImagePasso" },
                values: new object[,]
                {
                    { 1, "Pode candidatar-se online à posição que lhe interessa através da opção “Candidatura”. Terá a oportunidade de partilhar as suas competências, formação e experiência profissional connosco.", "" },
                    { 2, "Cada candidatura é cuidadosamente analisada pelos nossos especialistas de recrutamento. A nossa pré-seleção foca-se na combinação de elementos relativos à sua formação, percurso e experiência profissional. Esta fase permite-nos avaliar os dados curriculares e analisar se se enquadram com a missão da função para a qual estamos a recrutar.", "" },
                    { 3, "Se a sua candidatura for bem sucedida, neste fase irá conhecer os vários intervenientes da função a que se está a candidatar. Neste processo pode saber mais sobre o Grupo e sobre o projeto em causa. A nós permite-nos conhecer as suas motivações e analisar as suas competências técnicas e comportamentais. Esta etapa pode incluir várias e diferentes interações sobre a forma de entrevistas, exercícios práticos ou dinâmicas de grupo, dependendo da função em causa.", "" },
                    { 4, "Os vários intervenientes neste processo reúnem-se e tomam uma decisão.", "" },
                    { 5, "Se a sua candidatura for bem sucedida em todas as fases anteriores, irá receber um contacto nosso com uma oferta de emprego. Em caso de ficar excluído deste processo receberá também uma notificação por email.", "" },
                    { 6, "O seu processo de integração inicia-se na data da sua admissão e tem uma duração entre 30 a 90 dias, dependendo da função. Nessa altura é traçado um plano personalizado de integração e formação que será o ponto de partida de um caminho que lhe permita maximizar o seu potencial dentro do nosso Grupo.", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passos");

            migrationBuilder.AlterColumn<string>(
                name: "ImageSlider",
                table: "SliderTop",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonImage",
                table: "SliderTestemunhas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageRepresentative",
                table: "QuemSomos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageBrand",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
