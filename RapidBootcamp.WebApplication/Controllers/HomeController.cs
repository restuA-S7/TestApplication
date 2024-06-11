using Microsoft.AspNetCore.Mvc;


namespace RapidBootcamp.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        //ini namanya action action result bertipe interface
        public IActionResult Index()
        {
            //return Content("Hello restu aji s");
            //buat kirim data bisa pakai view data dan view back
            
            
            return View();
        }

        public IActionResult Privat()
        {
            
            return View();
            //kalau sama nama file beda maka harus diperbaiki dengan spesifik
            //jadi return View(privacy) misal namanya beda gitu antara nama file dan publicnya
        }
    }
}
