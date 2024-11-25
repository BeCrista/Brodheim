using Brodheim.Models;
using Brodheim.Models.ViewModels;
using BrodheimDataAccess.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Brodheim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var viewModel = new HomePageVM();

            // Fetch data from the ApplicationDbContext for each model
            viewModel.HomePageSlider = _dbContext.SliderTop.ToList(); // Assuming you want to fetch the first slider (you can change this as per your requirements)
            viewModel.QuemSomos = _dbContext.QuemSomos.ToList(); // Assuming you want to fetch the first QuemSomos entry
            viewModel.HomePageSlidersTestemunhas = _dbContext.SliderTestemunhas.ToList(); // Assuming you want to fetch the first HomePageSlidersTestemunhas entry
            viewModel.Brands = _dbContext.Brands.ToList(); // Assuming you want to fetch the first Brands entry

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Carreiras()
        {
            var viewModel = new CarreirasVM();

            viewModel.PassosList = _dbContext.Passos.ToList();
            return View(viewModel);
        }

        public IActionResult Oportunidades()
        {
            var viewModel = new OportunidadesVM();
            viewModel.OportunidadesList = _dbContext.Oportunidades.ToList();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> JobDetails(int id)
        {
            // Retrieve the job opportunity from the database using the provided ID
            var jobOpportunity = _dbContext.Oportunidades.FirstOrDefault(o => o.ID == id);

            if (jobOpportunity == null)
            {
                // If the job opportunity with the provided ID is not found, return a 404 page or an error view
                return NotFound();
            }

            // Pass the job opportunity to the view to display the details
            return View(jobOpportunity);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}