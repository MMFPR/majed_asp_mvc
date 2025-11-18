using majed_asp_mvc.Dtos;
using majed_asp_mvc.Interfaces.IServices;
using majed_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace majed_asp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("login")]
        public ActionResult<LoginResponsetDto> Login([FromQuery] LoginRequestDto loginRequest)
        {
            if (loginRequest.Email == "user@gmail.com" && loginRequest.Password == "1234")
            {

                var response = new LoginResponsetDto
                {
                    IsSuccus = true,
                    FirstName = "Majed",
                    Email = "user@gmail.com",
                };

                return Ok(response);
            }
            return Unauthorized("Invalid email or password");
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] UserDto registerRequest)
        {
            try
            {
                var existingUser = _userService.IsEmailExist(registerRequest.Email);
                if (existingUser)
                {
                    return BadRequest("User already exists.");
                }

                var newUser = new User
                {
                    FirstName = registerRequest.FirstName,
                    LastName = registerRequest.LastName,
                    Gender = registerRequest.Gender,
                    Birthday = registerRequest.Birthday,
                    Country = registerRequest.Country,
                    Email = registerRequest.Email,
                    Password = registerRequest.Password,
                    Phone = registerRequest.Phone,
                }
                ;

                _userService.Create(newUser);

                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                return BadRequest($"{message} حدث خطا غير متوقع ");
            }
        }




    }
}
