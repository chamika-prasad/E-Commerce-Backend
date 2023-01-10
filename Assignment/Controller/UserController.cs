using Assignment.Error;
using Assignment.Interface;
using Assignment.Request;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Security.Cryptography;
using System.Text;

namespace Assignment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _context;
        
        public UserController(IUserService context)
        {
            _context = context;
        }

        //User Registration

        [HttpPost("register")]

        public IActionResult Register(UserRequest request)
        {

            var response = _context.UserRegistration(request);  

            return response.State == false ? BadRequest(response) : Ok(response);

        }

        //User Login

        [HttpPost("login")]

        public IActionResult Login(UserRequest request)
        {

            var response = _context.UserLoging(request);

            return response.State == false ? BadRequest(response) : Ok(response);

        }

    }
}
