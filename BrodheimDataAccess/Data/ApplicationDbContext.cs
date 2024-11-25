using BrodheimModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrodheimDataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<HomePageSlider> sliders { get; set; }

        //Criar dados
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<HomePageSlider>().HasData(
                new HomePageSlider { ID = 1, Title = "Grupo Brodheim", SubTitle = "Mais de 70 anos de experiência a representar marcas premium e de luxo na Moda e na Ótica", ImageSlider =""},
                new HomePageSlider { ID = 2, Title = "Carreiras Brodheim", SubTitle = "O nosso crescimento é assente em 5 valores: Credibilidade, Sustentabilidade, Ambição, Empowerment e Atitude.", ImageSlider =""},
                new HomePageSlider { ID = 3, Title = "Trabalhar na Brodheim", SubTitle = "Na Brodheim, somos apaixonados pelo que fazemos!", ImageSlider =""}
                );
        }

    }
}