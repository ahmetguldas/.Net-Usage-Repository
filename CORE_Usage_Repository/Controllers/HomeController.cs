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
            return View(_repository.Products);
            //return View (_repository.Products.Where(x=>x.Price < 15).ToList());//IQueryable ifade ile beraber where filtresi ile flitrelemis oldugumuz verileri getir diyoruz.yani aslinda filtrelerimi bu sorgumun icerisine eklemis oluyoruz ve son IQueryable olusturulana kadarda bu isleme devam ediyoruz.
        }

        [HttpGet]
        public IActionResult Insert() => View(); //Bu action metot bize sadece ilgili View i return edecek

        [HttpPost]
        public IActionResult Insert(Product item)
        {
            _repository.InsertProduct(item);
            return RedirectToAction("Index");//Yukarida ki index action inina donecek ve listemi gosterecektir.
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_repository.GetById(id));//Guncelleme islemi icin urun bulunarak, ilgili View da formun dolu gelmesi gerekiyor
        }
        
        [HttpPost]
        public IActionResult Update(Product item)
        {
            _repository.UpdateProduct(item);                                                                                                                                                                                                                                                                                                                                                                                                                     
            return RedirectToAction("Index"); //Guncelledikten sonra listeye donsun.
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