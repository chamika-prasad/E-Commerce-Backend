using Assignment.Interface;
using Assignment.Request;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _IUserService;
        
        public UserController(IUserService IUserService)
        {
            _IUserService = IUserService;
        }

        //User Registration

        [HttpPost("Register")]

        public IActionResult Register(UserRequest request)
        {

            var response = _IUserService.UserRegistration(request);  

            return response.State == false ? BadRequest(response) : Ok(response);

        }

        //User Login

        [HttpPost("Login")]

        public IActionResult Login(UserRequest request)
        {

            var response = _IUserService.UserLoging(request);

            return response.State == false ? BadRequest(response) : Ok(response);

        }

    }
}
