using Microsoft.AspNetCore.Mvc;

namespace majed_asp_mvc.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
