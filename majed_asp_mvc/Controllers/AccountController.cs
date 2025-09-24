using majed_asp_mvc.Data;
using Microsoft.AspNetCore.Mvc;

namespace majed_asp_mvc.Controllers
{
    public class AccountController : Controller
    {

        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }




        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }


        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Employees
                .FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null) 
            {
                // فتح السيشن
                HttpContext.Session.SetString("UserEmail", user.Email);



                // التوجيه للصفحة المطلوبة
                return RedirectToAction("Index", "Home");
            }
            return View();
        }








    }
}
