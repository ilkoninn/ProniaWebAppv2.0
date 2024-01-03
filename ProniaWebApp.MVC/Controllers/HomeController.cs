using Microsoft.AspNetCore.Mvc;

namespace ProniaWebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
