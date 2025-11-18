using majed_asp_mvc.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace majed_asp_mvc.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            var users = _userService.GetAll();

            return View(users);
        }
    }
}
