using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoteService.Models;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace userService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly JWTConfig _jWTConfig;

        public UserController(IOptions<JWTConfig> jwtConfig)
        {
            _jWTConfig = jwtConfig.Value;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost("Register")]
        public User Register([FromBody] User user)
        {


            //var lastLine = System.IO.File.ReadLines(@"c:\Users\Adnanul Anwar\Desktop\users.txt").LastOrDefault(); // for txt file

            string[] lines = System.IO.File.ReadAllLines(@"c:\Users\Adnanul Anwar\Desktop\users.txt");
            List<User> users = new List<User>();

            if (lines != null || lines.Length > 0)
            {
                foreach (var row in lines)
                {
                    User tempUser = new User();
                    tempUser.UserID = int.Parse(row.Split("~~")[0]);
                    tempUser.Name = row.Split("~~")[1];
                    tempUser.Email = row.Split("~~")[2];
                    tempUser.Password = row.Split("~~")[3];
                    tempUser.DateOfBirth = DateTime.Parse(row.Split("~~")[4]);

                    users.Add(user);
                }


                var newUser = users.FirstOrDefault(x => x.Email == user.Email || x.Name == user.Name);

                if (newUser != null)
                {
                    user.ErrorMessage = "User Already Exists";
                    return user;
                }
                user.UserID = lines.Length + 1;
            }

            else
            {
                user.UserID = 1;
            }


            string userStr = user.UserID + "~~" + user.Name + "~~" + user.Email + "~~" + user.Password + "~~" + user.DateOfBirth;

            System.IO.File.AppendAllText(@"c:\Users\Adnanul Anwar\Desktop\users.txt", userStr + Environment.NewLine);
            return user;
        }


        [HttpPost("Login")]
        public User Login([FromBody] User user)
        {
            string[] lines = System.IO.File.ReadAllLines(@"c:\Users\Adnanul Anwar\Desktop\users.txt");
            List<User> users = new List<User>();

            if (lines != null || lines.Length > 0)
            {
                foreach (var row in lines)
                {
                    User tempUser = new User();
                    tempUser.UserID = int.Parse(row.Split("~~")[0]);
                    tempUser.Name = row.Split("~~")[1];
                    tempUser.Email = row.Split("~~")[2];
                    tempUser.Password = row.Split("~~")[3];
                    tempUser.DateOfBirth = DateTime.Parse(row.Split("~~")[4]);

                    users.Add(tempUser);
                }

            }
            var loginUser = users.FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
            if (loginUser == null)
            {
                user.ErrorMessage = "Invalid UserName Password";
                return user;

            }
            user.UserID = loginUser.UserID;
            user.Key = GenerateToken(user);
            return user;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private string GenerateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jWTConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] {
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.NameId,user.UserID.ToString()),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.UniqueName,user.Name),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jWTConfig.Audience,
                Issuer = _jWTConfig.Issuer
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
