using LoginMangement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;

namespace LoginMangement.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;     
        private readonly IConfiguration _configuration;    
        public LoginController(UserManager<ApplicationUser> user, IConfiguration configuration)
        {
            _userManager = user;
            _configuration = configuration;
        }

        public LoginController(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        [HttpGet]
        [Authorize]
        [Authorize(Roles = UserRoles.Admin)]
        public string get()
        {
            return "Hello World";
        }

        [HttpGet]
        [Route("loginuserdetail")]
        public async Task<UserRegisterTbl> Get(string user)
        {
            Response response = new Response();
            try
            {
                UserRegisterTbl tbl = new UserRegisterTbl();
                var userres = await _userManager.FindByNameAsync(user);
                if (userres != null)
                {
                    tbl.UserName = userres.UserName;
                    tbl.Email = userres.Email;
                    return tbl;
                }
                else
                    throw new Exception("failed to find user");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = "Error";
                response.StatusCode = StatusCodes.Status500InternalServerError.ToString();
            }
            return null;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterTbl userRegister)
        {
            Response response = new Response();
            try
            {
                var userExist = await _userManager.FindByNameAsync(userRegister.UserName);
                if (userExist != null)
                {
                    response.Message = "User Already Exists";
                    response.Status = "Error";
                    response.StatusCode = StatusCodes.Status500InternalServerError.ToString();
                    throw new Exception(response.Message);
                }
                ApplicationUser user = new ApplicationUser()
                {
                    Email = userRegister.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = userRegister.UserName
                };
                var result = await _userManager.CreateAsync(user, userRegister.Password);
                if (!result.Succeeded)
                {
                    string message = String.Empty;
                    foreach (var err in result.Errors)
                    {
                        var m = err.Description.ToString();
                        message += m;
                    }
                    response.Message = message;
                    throw new Exception(response.Message);
                }
                //if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                //    //await _roleManager.CreateAsync(new Model.IdentityRole(UserRoles.User));
                //if (await _roleManager.RoleExistsAsync(UserRoles.User))
                //{
                //    await _userManager.AddToRoleAsync(user, UserRoles.User);
                //}

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = "Error";
                response.StatusCode = StatusCodes.Status404NotFound.ToString();
                return NotFound(response);
            }
            response.Status = "Success";
            response.Message = "User Created Successfully";
            response.StatusCode = StatusCodes.Status200OK.ToString();
            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginTbl userLogin)
        {
            Response response = new Response();
            try
            {
                var user = await _userManager.FindByNameAsync(userLogin.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, userLogin.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var authClaim = new List<Claim>{
                        new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                    };
                    foreach (var userRole in userRoles)
                    {
                        authClaim.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                    var authSignKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:Issuer"],
                        audience: _configuration["JWT:Audience"],
                        expires: DateTime.Now.AddHours(5),
                        claims: authClaim,
                        signingCredentials: new SigningCredentials(authSignKey, SecurityAlgorithms.HmacSha256)
                        );
                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = "Error";
                response.StatusCode = StatusCodes.Status404NotFound.ToString();
                return NotFound(response);
            }

            response.Message = "Unauthorized User";
            response.Status = "Error";
            response.StatusCode = StatusCodes.Status401Unauthorized.ToString();
            return Unauthorized(response);
        }

        private IActionResult Unauthorized(Response response)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("registeradmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserRegisterTbl userRegister)
        {
            Response response = new Response();
            try
            {
                var userExist = await _userManager.FindByNameAsync(userRegister.UserName);
                if (userExist != null)
                {
                    response.Message = "User Already Exists";
                    response.Status = "Error";
                    response.StatusCode = StatusCodes.Status500InternalServerError.ToString();
                    throw new Exception();
                }
                ApplicationUser user = new ApplicationUser()
                {
                    Email = userRegister.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = userRegister.UserName
                };
                var result = await _userManager.CreateAsync(user, userRegister.Password);
                if (!result.Succeeded)
                {
                    string message = String.Empty;
                    foreach (var err in result.Errors)
                    {
                        var m = err.Description.ToString();
                        message += m;
                    }
                    response.Message = message;
                    throw new Exception(response.Message);
                }
                //if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                //    //await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                //if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                //    //await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                //if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                //{
                //    await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                //}
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = "Error";
                response.StatusCode = StatusCodes.Status404NotFound.ToString();
                return NotFound(response);
            }
            response.Status = "Success";
            response.Message = "User Created Successfully";
            response.StatusCode = StatusCodes.Status200OK.ToString();
            return Ok(response);
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Login1", "Login2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
