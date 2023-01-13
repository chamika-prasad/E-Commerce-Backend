using Assignment.Error;
using Assignment.Interface;
using Assignment.Request;
using DataAccess;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Assignment.Service
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;
        private UserErrorResponseHandler _response;
        private readonly IConfiguration _configuration;
        public UserService(DatabaseContext context, IConfiguration configuration) 
        {
            _context = context;
            _configuration = configuration;
        }


        //Registration

        public UserErrorResponseHandler UserRegistration(UserRequest request)
        {

            if (_context.Users.Any(u => u.email == request.email))
            {
                _response = SetResponse(false, "User already exists", "Customer", null);
                return _response;
            }

            try {

                var user = new User
                {
                    email = request.email,
                    password = request.password,
                    isAdmin = false,
                    token = "",
                };

                _context.Users.Add(user);
                _context.SaveChangesAsync();

                _response = SetResponse(true, "User added successfully","Customer", user);


            }
            catch(Exception ex)
            {
                _response = SetResponse(false, "Something went wrong", "Customer", null);

            }

            return _response;

        }

        //Loging

        public UserErrorResponseHandler UserLoging(UserRequest request)
        {
            var user = _context.Users.Where(u => u.email == request.email && u.password == request.password).FirstOrDefault();

            var admin = _context.Users.Where(u => u.email == request.email && u.password == request.password && u.isAdmin == true).FirstOrDefault();

            var customer = _context.Users.Where(u => u.email == request.email && u.password == request.password && u.isAdmin == false).FirstOrDefault();

            if (user == null)
            {
                _response = SetResponse(false, "Loging failed", "User name or password is incorrect", user);

                return _response;
            }
            else
            {
                if (admin == null)
                {
                    string userjwtToken = CreateJwtTokenUser(customer);

                    var mycustomer = GetUser(request);

                    mycustomer.token = userjwtToken;

                    _context.Users.Update(mycustomer);
                    _context.SaveChangesAsync();

                    _response = SetResponse(true, "Customer logged successfully", "Customer", customer);

                    return _response;
                }
                string adminjwtToken = CreateJwtTokenAdmin(admin);
                var myadmin = GetUser(request);

                myadmin.token = adminjwtToken;

                _context.Users.Update(myadmin);
                _context.SaveChangesAsync();

                _response = SetResponse(true, "Admin logged successfully", "Admin", admin);

                return _response;
            }

        }

        //Create admin JWT
        private string CreateJwtTokenAdmin(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.Role, "Admin"),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }



        //Create Customer JWT
        private string CreateJwtTokenUser(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.Role, "Customer"),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        //Get user
        public User GetUser(UserRequest request)
        {
            var user = _context.Users.Where(u => u.email == request.email).FirstOrDefault();

            return user;
        }

        private UserErrorResponseHandler SetResponse(bool state,string message,string user,User detail)
        {
            UserErrorResponseHandler response = new UserErrorResponseHandler
            {
                State = state,
                Message = message,
                User = user,
                Detail = detail,
            };

            return response;
        }
    }
}
