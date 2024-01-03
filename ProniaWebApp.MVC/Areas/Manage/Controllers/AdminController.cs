using Microsoft.AspNetCore.Mvc;

namespace ProniaWebApp.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AdminController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
