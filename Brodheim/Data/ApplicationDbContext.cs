﻿using Brodheim.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Brodheim
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<HomePageSlider> SliderTop { get; set; }

        public DbSet<QuemSomos> QuemSomos { get; set; }

        public DbSet<HomePageSlidersTestemunhas> SliderTestemunhas { get; set; }

        public DbSet<Brands> Brands { get; set; }

        public DbSet<Passos> Passos { get; set; }

        public DbSet<Oportunidades> Oportunidades { get; set; }

        //Criar dados
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<HomePageSlider>().HasData(
                new HomePageSlider { ID = 1, Title = "Grupo Brodheim", SubTitle = "Mais de 70 anos de experiência a representar marcas premium e de luxo na Moda e na Ótica", ImageSlider =""},
                new HomePageSlider { ID = 2, Title = "Carreiras Brodheim", SubTitle = "O nosso crescimento é assente em 5 valores: Credibilidade, Sustentabilidade, Ambição, Empowerment e Atitude.", ImageSlider =""},
                new HomePageSlider { ID = 3, Title = "Trabalhar na Brodheim", SubTitle = "Na Brodheim, somos apaixonados pelo que fazemos!", ImageSlider =""}
                );

            builder.Entity<QuemSomos>().HasData(
                new QuemSomos { ID = 1, NameRepresentative = "Colaboradores", QuantityRepresentative = 600, ImageRepresentative = ""},
                new QuemSomos { ID = 2, NameRepresentative = "Lojas", QuantityRepresentative = 70, ImageRepresentative = ""},
                new QuemSomos { ID = 3, NameRepresentative = "Marcas", QuantityRepresentative = 12, ImageRepresentative = ""}
                );

            builder.Entity<HomePageSlidersTestemunhas>().HasData(
                new HomePageSlidersTestemunhas { ID = 1, NamePerson = "Alexandra", PersonPosition = "Visual Merchandising", Description = "É um privilégio poder contribuir diariamente e partilhar a vontade de acresentar valor ao negócio, numa cultura aberta, onde o erro faz parte do crescimento, o sentimento de pertença é grande, e o reconhecimento e as celebrações são enormes!", PersonImage = "" },
                new HomePageSlidersTestemunhas { ID = 2, NamePerson = "André", PersonPosition = "Store Manager", Description = "Pertencer ao Grupo Brodheim é um desafio permanente, onde o fator humano está sempre presente. Aqui, desenvolvi a minha carreira. Comecei a trabalhar na Sede nos Recursos Humanos, e, entretanto, surgiu a oportunidade de ser Back Office Coordinator onde dou apoio a uma das principais lojas do Grupo.", PersonImage = "" },
                new HomePageSlidersTestemunhas { ID = 3, NamePerson = "Bruno", PersonPosition = "Store Manager", Description = "Todas as vitórias e obstáculos foram importantes para me tornar o profissional que sou hoje. As conquistas de que mais me orgulho são: os colegas que ajudei a desenvolver, as formações que pude dar e os prémios coletivos e individuais que tenho conquistado.", PersonImage = "" },
                new HomePageSlidersTestemunhas { ID = 4, NamePerson = "Igor", PersonPosition = " Treasury & Credit Control", Description = "Trabalhar no Grupo Brodheim é fazer parte de uma estrutura que privilegia o trabalho em equipa, significa ter certeza de estar dentro de um projeto vencedor com grandes líderes, pessoas inspiradoras que incentivam a progredir. A Brodheim abriu-me as portas do mercado profissional para a minha área de formação.", PersonImage = "" },
                new HomePageSlidersTestemunhas { ID = 5, NamePerson = "Lídia", PersonPosition = " Head of Customer & Digital Marketing", Description = "“Desafio” resume o que é trabalhar na Brodheim. Somos constantemente desafiados: a pensar “fora da caixa”, a ter autonomia, a ter novas missões, a aprender pela experiência sem receio de errar, a fazer aquilo que nos apaixona dentro e fora da empresa e a viver os valores da mesma.", PersonImage = "" },
                new HomePageSlidersTestemunhas { ID = 6, NamePerson = "Jorge", PersonPosition = "Store Manager", Description = "Trabalhar no grupo Brodheim é um orgulho e uma satisfação enorme. A grandiosidade da empresa, a sua tradição, o reconhecimento e respeito que parceiros e clientes têm por nós, desde os seus valores, princípios, responsabilidades sociais e ecológicas. O grupo dá-me a oportunidade de crescer em várias valências e competências, é um lugar que valoriza os profissionais, dando oportunidades para todos mostrarem o seu potencial.", PersonImage = "" },
                new HomePageSlidersTestemunhas { ID = 7, NamePerson = "Manuela", PersonPosition = "Store Manager", Description = "Gosto muito de fazer parte de uma empresa que desenvolve os colaboradores tanto a nível profissional como pessoal. Todos os dias aprendo muito acerca dos outros e de mim própria. Há sempre atitude, há sempre paixão, e um entusiasmo contagiante!", PersonImage = "" },
                new HomePageSlidersTestemunhas { ID = 8, NamePerson = "Pedro", PersonPosition = "Area Manager", Description = "Trabalhar na Brodheim é ser parte de uma história com mais de 70 anos; é trabalhar com vontade, com garra de vencer e de superar! Comecei como vendedor, fui ultrapassando todos os desafios que me foram propostos, até me tornar Area Manager, função que desempenho hoje.", PersonImage = "" },
                new HomePageSlidersTestemunhas { ID = 9, NamePerson = "Sofia", PersonPosition = " People & Talent Development", Description = "Trabalhar na Brodheim é fazer parte de uma cultura forte, onde os seus valores são vividos diariamente. É fazer parte de um projeto de responsabilidade social sólido, no qual as equipas estão envolvidas. É estar no Top 20 das melhores empresas para trabalhar em Portugal. É querer sempre mais!", PersonImage = "" }
                );

            builder.Entity<Brands>().HasData(
                new Brands { ID = 1, ImageBrand = ""},
                new Brands { ID = 2, ImageBrand = ""},
                new Brands { ID = 3, ImageBrand = ""},
                new Brands { ID = 4, ImageBrand = ""},
                new Brands { ID = 5, ImageBrand = ""},
                new Brands { ID = 6, ImageBrand = ""},
                new Brands { ID = 7, ImageBrand = ""},
                new Brands { ID = 8, ImageBrand = ""},
                new Brands { ID = 9, ImageBrand = ""},
                new Brands { ID = 10, ImageBrand = ""},
                new Brands { ID = 11, ImageBrand = ""},
                new Brands { ID = 12, ImageBrand = ""},
                new Brands { ID = 13, ImageBrand = ""},
                new Brands { ID = 14, ImageBrand = ""}
                );

            builder.Entity<Passos>().HasData(
                new Passos { ID = 1, ImagePasso = "", DescricaoPasso = "Pode candidatar-se online à posição que lhe interessa através da opção “Candidatura”. Terá a oportunidade de partilhar as suas competências, formação e experiência profissional connosco."},
                new Passos { ID = 2, ImagePasso = "", DescricaoPasso = "Cada candidatura é cuidadosamente analisada pelos nossos especialistas de recrutamento. A nossa pré-seleção foca-se na combinação de elementos relativos à sua formação, percurso e experiência profissional. Esta fase permite-nos avaliar os dados curriculares e analisar se se enquadram com a missão da função para a qual estamos a recrutar." },
                new Passos { ID = 3, ImagePasso = "", DescricaoPasso = "Se a sua candidatura for bem sucedida, neste fase irá conhecer os vários intervenientes da função a que se está a candidatar. Neste processo pode saber mais sobre o Grupo e sobre o projeto em causa. A nós permite-nos conhecer as suas motivações e analisar as suas competências técnicas e comportamentais. Esta etapa pode incluir várias e diferentes interações sobre a forma de entrevistas, exercícios práticos ou dinâmicas de grupo, dependendo da função em causa." },
                new Passos { ID = 4, ImagePasso = "", DescricaoPasso = "Os vários intervenientes neste processo reúnem-se e tomam uma decisão." },
                new Passos { ID = 5, ImagePasso = "", DescricaoPasso = "Se a sua candidatura for bem sucedida em todas as fases anteriores, irá receber um contacto nosso com uma oferta de emprego. Em caso de ficar excluído deste processo receberá também uma notificação por email." },
                new Passos { ID = 6, ImagePasso = "", DescricaoPasso = "O seu processo de integração inicia-se na data da sua admissão e tem uma duração entre 30 a 90 dias, dependendo da função. Nessa altura é traçado um plano personalizado de integração e formação que será o ponto de partida de um caminho que lhe permita maximizar o seu potencial dentro do nosso Grupo." }
                );

            builder.Entity<Oportunidades>().HasData(
                new Oportunidades { ID = 1, NomeTrabalho = "Sales Assistant (M/F) – Vans Funchal | FT", NomeEmpresa = "Vans", ImageEmpresa = "", Localizacao = "Funchal", NomeFuncao = "Sales Assistant", DetalhesFuncao = "Com mais de 75 anos de história e crescimento, o Grupo Brodheim é hoje a mais importante empresa de moda e ótica em Portugal. Com a visão de ser a referência na gestão de retalho premium no mundo da moda e da ótica, é considerada uma das Melhores Empresas Para Trabalhar em Portugal, e o lugar onde tu queres estar! A missão de proporcionar a todos os nossos clientes e stakeholders, um serviço de excelência e uma experiência comercial e relacional única, é sentida e vivida todos os dias pelos nossos colaboradores que incorporam os nossos valores: ambição, sustentabilidade, credibilidade, empowerment e atitude.\r\n\r\nVeste a camisola VANS, na nossa loja no MadeiraShopping, em regime Full-Time 40h (rotativo).\r\n\r\nA TUA MISSÃO:\r\n– Garantir uma experiência comercial de excelência\r\n– Garantir vendas\r\n– Assegurar as tarefas diárias da loja\r\n– Reportar diretamente ao Store Manager\r\n\r\nQUE PERFIL PROCURAMOS?\r\nO candidato ideal terá o seguinte perfil:\r\n– Experiência no retalho, em marcas do mesmo segmento (preferencial)\r\n– Gosto por proporcionar uma experiência comercial excecional\r\n– Ótimas competências comunicacionais\r\n– Elevado perfil comercial\r\n– Foco no cumprimento de objetivos\r\n– Conhecimentos de inglês em contexto de vendas\r\n– Disponibilidade para realizar horários rotativos e flexíveis\r\n– Carta de condução, viatura própria (requisito preferencial para deslocação para o shopping)\r\n\r\nO QUE TE OFERECEMOS:\r\n– Um ambiente de trabalho envolvente\r\n– Possibilidade de crescimento e progressão na carreira\r\n– Oportunidade de Formação especializada contínua\r\n– Incentivos mensais\r\n– Participação em ações de solidariedade social e ambiental\r\n– Protocolos e parcerias exclusivas para colaboradores do Grupo Brodheim\r\n\r\nSe reúnes os requisitos, esta vaga é para ti!", TipoContrato = "Full Time", DateTrabalho = new DateTime(2023, 7, 31) },
                new Oportunidades { ID = 2, NomeTrabalho = "Sales Assistant (M/F) – Timberland Amoreiras | PT", NomeEmpresa = "Timberland", ImageEmpresa = "", Localizacao = "Lisboa", NomeFuncao = "Sales Assistant", DetalhesFuncao = "Com mais de 75 anos de história e crescimento, o Grupo Brodheim é hoje a mais importante empresa de moda e ótica em Portugal. Com a visão de ser a referência na gestão de retalho premium no mundo da moda e da ótica, é considerada uma das Melhores Empresas Para Trabalhar em Portugal, e o lugar onde tu queres estar! A missão de proporcionar a todos os nossos clientes e stakeholders, um serviço de excelência e uma experiência comercial e relacional única, é sentida e vivida todos os dias pelos nossos colaboradores que incorporam os nossos valores: ambição, sustentabilidade, credibilidade, empowerment e atitude.\r\n\r\nVeste a camisola VANS, na nossa loja no MadeiraShopping, em regime Full-Time 40h (rotativo).\r\n\r\nA TUA MISSÃO:\r\n– Garantir uma experiência comercial de excelência\r\n– Garantir vendas\r\n– Assegurar as tarefas diárias da loja\r\n– Reportar diretamente ao Store Manager\r\n\r\nQUE PERFIL PROCURAMOS?\r\nO candidato ideal terá o seguinte perfil:\r\n– Experiência no retalho, em marcas do mesmo segmento (preferencial)\r\n– Gosto por proporcionar uma experiência comercial excecional\r\n– Ótimas competências comunicacionais\r\n– Elevado perfil comercial\r\n– Foco no cumprimento de objetivos\r\n– Conhecimentos de inglês em contexto de vendas\r\n– Disponibilidade para realizar horários rotativos e flexíveis\r\n– Carta de condução, viatura própria (requisito preferencial para deslocação para o shopping)\r\n\r\nO QUE TE OFERECEMOS:\r\n– Um ambiente de trabalho envolvente\r\n– Possibilidade de crescimento e progressão na carreira\r\n– Oportunidade de Formação especializada contínua\r\n– Incentivos mensais\r\n– Participação em ações de solidariedade social e ambiental\r\n– Protocolos e parcerias exclusivas para colaboradores do Grupo Brodheim\r\n\r\nSe reúnes os requisitos, esta vaga é para ti!", TipoContrato = "Part Time", DateTrabalho = new DateTime(2023, 7, 31) },
                new Oportunidades { ID = 3, NomeTrabalho = "Sales Assistant (M/F) – Emporio Armani (Full-Time)", NomeEmpresa = "Emporio Armani", ImageEmpresa = "", Localizacao = "Lisboa", NomeFuncao = "Sales Assistant", DetalhesFuncao = "Com mais de 75 anos de história e crescimento, o Grupo Brodheim é hoje a mais importante empresa de moda e ótica em Portugal. Com a visão de ser a referência na gestão de retalho premium no mundo da moda e da ótica, é considerada uma das Melhores Empresas Para Trabalhar em Portugal, e o lugar onde tu queres estar! A missão de proporcionar a todos os nossos clientes e stakeholders, um serviço de excelência e uma experiência comercial e relacional única, é sentida e vivida todos os dias pelos nossos colaboradores que incorporam os nossos valores: ambição, sustentabilidade, credibilidade, empowerment e atitude.\r\n\r\nVeste a camisola VANS, na nossa loja no MadeiraShopping, em regime Full-Time 40h (rotativo).\r\n\r\nA TUA MISSÃO:\r\n– Garantir uma experiência comercial de excelência\r\n– Garantir vendas\r\n– Assegurar as tarefas diárias da loja\r\n– Reportar diretamente ao Store Manager\r\n\r\nQUE PERFIL PROCURAMOS?\r\nO candidato ideal terá o seguinte perfil:\r\n– Experiência no retalho, em marcas do mesmo segmento (preferencial)\r\n– Gosto por proporcionar uma experiência comercial excecional\r\n– Ótimas competências comunicacionais\r\n– Elevado perfil comercial\r\n– Foco no cumprimento de objetivos\r\n– Conhecimentos de inglês em contexto de vendas\r\n– Disponibilidade para realizar horários rotativos e flexíveis\r\n– Carta de condução, viatura própria (requisito preferencial para deslocação para o shopping)\r\n\r\nO QUE TE OFERECEMOS:\r\n– Um ambiente de trabalho envolvente\r\n– Possibilidade de crescimento e progressão na carreira\r\n– Oportunidade de Formação especializada contínua\r\n– Incentivos mensais\r\n– Participação em ações de solidariedade social e ambiental\r\n– Protocolos e parcerias exclusivas para colaboradores do Grupo Brodheim\r\n\r\nSe reúnes os requisitos, esta vaga é para ti!", TipoContrato = "Full Time", DateTrabalho = new DateTime(2023, 7, 28) },
                new Oportunidades { ID = 4, NomeTrabalho = "Sales Assistant (M/F) – Timberland Outlet Vila do Conde | FT", NomeEmpresa = "Timberland", ImageEmpresa = "", Localizacao = "Vila do Conde - Porto", NomeFuncao = "Sales Assistant", DetalhesFuncao = "Com mais de 75 anos de história e crescimento, o Grupo Brodheim é hoje a mais importante empresa de moda e ótica em Portugal. Com a visão de ser a referência na gestão de retalho premium no mundo da moda e da ótica, é considerada uma das Melhores Empresas Para Trabalhar em Portugal, e o lugar onde tu queres estar! A missão de proporcionar a todos os nossos clientes e stakeholders, um serviço de excelência e uma experiência comercial e relacional única, é sentida e vivida todos os dias pelos nossos colaboradores que incorporam os nossos valores: ambição, sustentabilidade, credibilidade, empowerment e atitude.\r\n\r\nVeste a camisola VANS, na nossa loja no MadeiraShopping, em regime Full-Time 40h (rotativo).\r\n\r\nA TUA MISSÃO:\r\n– Garantir uma experiência comercial de excelência\r\n– Garantir vendas\r\n– Assegurar as tarefas diárias da loja\r\n– Reportar diretamente ao Store Manager\r\n\r\nQUE PERFIL PROCURAMOS?\r\nO candidato ideal terá o seguinte perfil:\r\n– Experiência no retalho, em marcas do mesmo segmento (preferencial)\r\n– Gosto por proporcionar uma experiência comercial excecional\r\n– Ótimas competências comunicacionais\r\n– Elevado perfil comercial\r\n– Foco no cumprimento de objetivos\r\n– Conhecimentos de inglês em contexto de vendas\r\n– Disponibilidade para realizar horários rotativos e flexíveis\r\n– Carta de condução, viatura própria (requisito preferencial para deslocação para o shopping)\r\n\r\nO QUE TE OFERECEMOS:\r\n– Um ambiente de trabalho envolvente\r\n– Possibilidade de crescimento e progressão na carreira\r\n– Oportunidade de Formação especializada contínua\r\n– Incentivos mensais\r\n– Participação em ações de solidariedade social e ambiental\r\n– Protocolos e parcerias exclusivas para colaboradores do Grupo Brodheim\r\n\r\nSe reúnes os requisitos, esta vaga é para ti!", TipoContrato = "Full Time", DateTrabalho = new DateTime(2023, 7, 26) },
                new Oportunidades { ID = 5, NomeTrabalho = "Warehouse Assistant (M/F) – Guess Outlet Loulé | FT", NomeEmpresa = "Guess", ImageEmpresa = "", Localizacao = "Loulé - Faro", NomeFuncao = "Warehouse Assistant", DetalhesFuncao = "Com mais de 75 anos de história e crescimento, o Grupo Brodheim é hoje a mais importante empresa de moda e ótica em Portugal. Com a visão de ser a referência na gestão de retalho premium no mundo da moda e da ótica, é considerada uma das Melhores Empresas Para Trabalhar em Portugal, e o lugar onde tu queres estar! A missão de proporcionar a todos os nossos clientes e stakeholders, um serviço de excelência e uma experiência comercial e relacional única, é sentida e vivida todos os dias pelos nossos colaboradores que incorporam os nossos valores: ambição, sustentabilidade, credibilidade, empowerment e atitude.\r\n\r\nVeste a camisola VANS, na nossa loja no MadeiraShopping, em regime Full-Time 40h (rotativo).\r\n\r\nA TUA MISSÃO:\r\n– Garantir uma experiência comercial de excelência\r\n– Garantir vendas\r\n– Assegurar as tarefas diárias da loja\r\n– Reportar diretamente ao Store Manager\r\n\r\nQUE PERFIL PROCURAMOS?\r\nO candidato ideal terá o seguinte perfil:\r\n– Experiência no retalho, em marcas do mesmo segmento (preferencial)\r\n– Gosto por proporcionar uma experiência comercial excecional\r\n– Ótimas competências comunicacionais\r\n– Elevado perfil comercial\r\n– Foco no cumprimento de objetivos\r\n– Conhecimentos de inglês em contexto de vendas\r\n– Disponibilidade para realizar horários rotativos e flexíveis\r\n– Carta de condução, viatura própria (requisito preferencial para deslocação para o shopping)\r\n\r\nO QUE TE OFERECEMOS:\r\n– Um ambiente de trabalho envolvente\r\n– Possibilidade de crescimento e progressão na carreira\r\n– Oportunidade de Formação especializada contínua\r\n– Incentivos mensais\r\n– Participação em ações de solidariedade social e ambiental\r\n– Protocolos e parcerias exclusivas para colaboradores do Grupo Brodheim\r\n\r\nSe reúnes os requisitos, esta vaga é para ti!", TipoContrato = "Full Time", DateTrabalho = new DateTime(2023, 7, 24) },
                new Oportunidades { ID = 6, NomeTrabalho = "Sales Assistant (M/F) – Michael Kors Aeroporto de Lisboa | FT", NomeEmpresa = "Michael Kors", ImageEmpresa = "", Localizacao = "Lisboa", NomeFuncao = "Sales Assistant", DetalhesFuncao = "Com mais de 75 anos de história e crescimento, o Grupo Brodheim é hoje a mais importante empresa de moda e ótica em Portugal. Com a visão de ser a referência na gestão de retalho premium no mundo da moda e da ótica, é considerada uma das Melhores Empresas Para Trabalhar em Portugal, e o lugar onde tu queres estar! A missão de proporcionar a todos os nossos clientes e stakeholders, um serviço de excelência e uma experiência comercial e relacional única, é sentida e vivida todos os dias pelos nossos colaboradores que incorporam os nossos valores: ambição, sustentabilidade, credibilidade, empowerment e atitude.\r\n\r\nVeste a camisola VANS, na nossa loja no MadeiraShopping, em regime Full-Time 40h (rotativo).\r\n\r\nA TUA MISSÃO:\r\n– Garantir uma experiência comercial de excelência\r\n– Garantir vendas\r\n– Assegurar as tarefas diárias da loja\r\n– Reportar diretamente ao Store Manager\r\n\r\nQUE PERFIL PROCURAMOS?\r\nO candidato ideal terá o seguinte perfil:\r\n– Experiência no retalho, em marcas do mesmo segmento (preferencial)\r\n– Gosto por proporcionar uma experiência comercial excecional\r\n– Ótimas competências comunicacionais\r\n– Elevado perfil comercial\r\n– Foco no cumprimento de objetivos\r\n– Conhecimentos de inglês em contexto de vendas\r\n– Disponibilidade para realizar horários rotativos e flexíveis\r\n– Carta de condução, viatura própria (requisito preferencial para deslocação para o shopping)\r\n\r\nO QUE TE OFERECEMOS:\r\n– Um ambiente de trabalho envolvente\r\n– Possibilidade de crescimento e progressão na carreira\r\n– Oportunidade de Formação especializada contínua\r\n– Incentivos mensais\r\n– Participação em ações de solidariedade social e ambiental\r\n– Protocolos e parcerias exclusivas para colaboradores do Grupo Brodheim\r\n\r\nSe reúnes os requisitos, esta vaga é para ti!", TipoContrato = "Full Time", DateTrabalho = new DateTime(2023, 7, 21) },
                new Oportunidades { ID = 7, NomeTrabalho = "Trade Marketing (M/F) – Substituição de Licença de Maternidade", NomeEmpresa = "Brodheim", ImageEmpresa = "", Localizacao = "Lisboa", NomeFuncao = "Trade Marketing", DetalhesFuncao = "Com mais de 75 anos de história e crescimento, o Grupo Brodheim é hoje a mais importante empresa de moda e ótica em Portugal. Com a visão de ser a referência na gestão de retalho premium no mundo da moda e da ótica, é considerada uma das Melhores Empresas Para Trabalhar em Portugal, e o lugar onde tu queres estar! A missão de proporcionar a todos os nossos clientes e stakeholders, um serviço de excelência e uma experiência comercial e relacional única, é sentida e vivida todos os dias pelos nossos colaboradores que incorporam os nossos valores: ambição, sustentabilidade, credibilidade, empowerment e atitude.\r\n\r\nVeste a camisola VANS, na nossa loja no MadeiraShopping, em regime Full-Time 40h (rotativo).\r\n\r\nA TUA MISSÃO:\r\n– Garantir uma experiência comercial de excelência\r\n– Garantir vendas\r\n– Assegurar as tarefas diárias da loja\r\n– Reportar diretamente ao Store Manager\r\n\r\nQUE PERFIL PROCURAMOS?\r\nO candidato ideal terá o seguinte perfil:\r\n– Experiência no retalho, em marcas do mesmo segmento (preferencial)\r\n– Gosto por proporcionar uma experiência comercial excecional\r\n– Ótimas competências comunicacionais\r\n– Elevado perfil comercial\r\n– Foco no cumprimento de objetivos\r\n– Conhecimentos de inglês em contexto de vendas\r\n– Disponibilidade para realizar horários rotativos e flexíveis\r\n– Carta de condução, viatura própria (requisito preferencial para deslocação para o shopping)\r\n\r\nO QUE TE OFERECEMOS:\r\n– Um ambiente de trabalho envolvente\r\n– Possibilidade de crescimento e progressão na carreira\r\n– Oportunidade de Formação especializada contínua\r\n– Incentivos mensais\r\n– Participação em ações de solidariedade social e ambiental\r\n– Protocolos e parcerias exclusivas para colaboradores do Grupo Brodheim\r\n\r\nSe reúnes os requisitos, esta vaga é para ti!", TipoContrato = "Full Time", DateTrabalho = new DateTime(2023, 7, 10) }
                );

        }

    }
}