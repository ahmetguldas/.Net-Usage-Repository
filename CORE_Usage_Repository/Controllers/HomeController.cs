using CORE_Usage_Repository.Models;
using CORE_Usage_Repository.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CORE_Usage_Repository.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _repository;

        public HomeController(ILogger<HomeController> logger, IProductRepository repository)
        {
            _repository = repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //return View(_repository.Products);
            return View (_repository.Products.Where(x=>x.Price < 15).ToList());//IQueryable ifade ile beraber where filtresi ile flitrelemis oldugumuz verileri getir diyoruz.yani aslinda filtrelerimi bu sorgumun icerisine eklemis oluyoruz ve son IQueryable olusturulana kadarda bu isleme devam ediyoruz.
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}