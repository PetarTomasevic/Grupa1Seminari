using Microsoft.AspNetCore.Mvc;

namespace Expert.RatkoMisic.Seminar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
