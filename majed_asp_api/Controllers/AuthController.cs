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


        //[HttpGet("login")]
        //public ActionResult<LoginResponse> Login([FromQuery] LoginRequestDto loginRequest)
        //{

        //    // Dummy authentication logic
        //    if (loginRequest.Email == "user@gmail.com" && loginRequest.Password == "123456")
        //    {

        //        var response = new LoginResponse
        //        {
        //            IsSuccess = true,
        //            FirstName = "Mohamed Alswaify",
        //            Email = "user@gmail.com",

        //        };


        //        return Ok(response);
        //    }
        //    return Unauthorized();

        //}


        [HttpGet("login")]
        public ActionResult<string> Login([FromQuery] LoginRequestDto loginRequest)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(loginRequest.Email) || string.IsNullOrWhiteSpace(loginRequest.Password))
                    return BadRequest("Username and password are required.");

                var token = _userService.GetByEmailAndPassword(loginRequest);
                if (token == null)
                    return Unauthorized("اسم المستخدم او كلمه المرور غير صحيحه"); // 401
                return Ok(token); // 200

            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                return BadRequest($"{message}حدث خطا غير متوقع");
            }

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
                    BirthDate = registerRequest.BirthDate,
                    Country = registerRequest.Country,
                    Email = registerRequest.Email,
                    Password = registerRequest.Password,
                    Phone = registerRequest.Phone,
                };

                _userService.Create(newUser);

                var result = new registerDto
                {
                    firstName = newUser.FirstName,
                    lastName = newUser.LastName,
                };


                return Ok(result);
            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                return BadRequest($"{message}حدث خطا غير متوقع");
            }
        }








    }
}
