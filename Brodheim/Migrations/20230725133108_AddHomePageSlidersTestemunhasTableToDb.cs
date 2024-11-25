using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BrodheimDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddHomePageSlidersTestemunhasTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SliderTestemunhas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderTestemunhas", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "SliderTestemunhas",
                columns: new[] { "ID", "Description", "NamePerson", "PersonImage", "PersonPosition" },
                values: new object[,]
                {
                    { 1, "É um privilégio poder contribuir diariamente e partilhar a vontade de acresentar valor ao negócio, numa cultura aberta, onde o erro faz parte do crescimento, o sentimento de pertença é grande, e o reconhecimento e as celebrações são enormes!", "Alexandra", "", "Visual Merchandising" },
                    { 2, "Pertencer ao Grupo Brodheim é um desafio permanente, onde o fator humano está sempre presente. Aqui, desenvolvi a minha carreira. Comecei a trabalhar na Sede nos Recursos Humanos, e, entretanto, surgiu a oportunidade de ser Back Office Coordinator onde dou apoio a uma das principais lojas do Grupo.", "André", "", "Store Manager" },
                    { 3, "Todas as vitórias e obstáculos foram importantes para me tornar o profissional que sou hoje. As conquistas de que mais me orgulho são: os colegas que ajudei a desenvolver, as formações que pude dar e os prémios coletivos e individuais que tenho conquistado.", "Bruno", "", "Store Manager" },
                    { 4, "Trabalhar no Grupo Brodheim é fazer parte de uma estrutura que privilegia o trabalho em equipa, significa ter certeza de estar dentro de um projeto vencedor com grandes líderes, pessoas inspiradoras que incentivam a progredir. A Brodheim abriu-me as portas do mercado profissional para a minha área de formação.", "Igor", "", " Treasury & Credit Control" },
                    { 5, "“Desafio” resume o que é trabalhar na Brodheim. Somos constantemente desafiados: a pensar “fora da caixa”, a ter autonomia, a ter novas missões, a aprender pela experiência sem receio de errar, a fazer aquilo que nos apaixona dentro e fora da empresa e a viver os valores da mesma.", "Lídia", "", " Head of Customer & Digital Marketing" },
                    { 6, "Trabalhar no grupo Brodheim é um orgulho e uma satisfação enorme. A grandiosidade da empresa, a sua tradição, o reconhecimento e respeito que parceiros e clientes têm por nós, desde os seus valores, princípios, responsabilidades sociais e ecológicas. O grupo dá-me a oportunidade de crescer em várias valências e competências, é um lugar que valoriza os profissionais, dando oportunidades para todos mostrarem o seu potencial.", "Jorge", "", "Store Manager" },
                    { 7, "Gosto muito de fazer parte de uma empresa que desenvolve os colaboradores tanto a nível profissional como pessoal. Todos os dias aprendo muito acerca dos outros e de mim própria. Há sempre atitude, há sempre paixão, e um entusiasmo contagiante!", "Manuela", "", "Store Manager" },
                    { 8, "Trabalhar na Brodheim é ser parte de uma história com mais de 70 anos; é trabalhar com vontade, com garra de vencer e de superar! Comecei como vendedor, fui ultrapassando todos os desafios que me foram propostos, até me tornar Area Manager, função que desempenho hoje.", "Pedro", "", "Area Manager" },
                    { 9, "Trabalhar na Brodheim é fazer parte de uma cultura forte, onde os seus valores são vividos diariamente. É fazer parte de um projeto de responsabilidade social sólido, no qual as equipas estão envolvidas. É estar no Top 20 das melhores empresas para trabalhar em Portugal. É querer sempre mais!", "Sofia", "", " People & Talent Development" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SliderTestemunhas");
        }
    }
}
