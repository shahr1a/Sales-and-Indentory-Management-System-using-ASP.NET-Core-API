using BusinessLogicLayer.BusinessEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesAndInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        //    private BusinessLogicLayer.Services.UserService _BLL;
        //    readonly IConfiguration _configuration;
        //    public UserController(IConfiguration configuration)
        //    {
        //        _BLL = new BusinessLogicLayer.Services.UserService();
        //        _configuration = configuration;
        //    }
        //    [Route("Login")]
        //    [AllowAnonymous]
        //    [HttpPost]
        //    public async Task<IActionResult> Login(UserModel userModel)
        //    {
        //        UserModel? user = await _BLL.VerifyUser(userModel);
        //        if (user == null) return BadRequest();
        //        else
        //        {
        //            string token = BuildToken(_configuration["Jwt:Key"], _configuration["Jwt:Issuer"], user);
        //            return Ok(new { User = user, Token = token });
        //        }
        //        // return Ok("seems ok");
        //        //Dealer dealer = new Dealer();
        //        //int id;
        //        //bool isVerified = false, isAdmin = false;
        //        //if (usertype == "staff")
        //        //{
        //        //    user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        //        //    if (user == null)
        //        //    {
        //        //        ViewBag.Error = "Username or passwords do not match";
        //        //        return View();
        //        //    }
        //        //    id = user.Id;
        //        //    isVerified = user.IsVerified;
        //        //    isAdmin = user.IsAdmin;
        //        //}
        //        //else
        //        //{
        //        //    dealer = _context.Dealers.FirstOrDefault(u => u.DealerUsername == username && u.DealerPassword == password);
        //        //    if (dealer == null)
        //        //    {
        //        //        ViewBag.Error = "Username or passwords do not match";
        //        //        return View();
        //        //    }
        //        //    id = dealer.Id;
        //        //    isVerified = dealer.IsVerified;
        //        //    isAdmin = false;
        //        //}
        //        //List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.Name, username), new Claim(ClaimTypes.Role, isAdmin.ToString()) };
        //        //ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Login");
        //        //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        //        //HttpContext.Session.SetString("usertype", usertype);
        //        //HttpContext.Session.SetString("isVerified", isVerified.ToString());
        //        //HttpContext.Session.SetInt32("userId", id);
        //        //if (!isVerified)
        //        //    TempData["message"] = "Verify account by updating password";
        //        //return Redirect("/Home");
        //    }

        //    [Route("Logout")]
        //    [HttpGet]
        //    public async Task<IActionResult> Logout()
        //    {
        //        return Ok(HttpContext.User.Claims.First().ToString());
        //    }

        //    private string BuildToken(string key, string issuer, UserModel user)
        //    {
        //        var claims = new[]
        //        {
        //            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
        //            new Claim(ClaimTypes.Role, user.IsAdmin.ToString())
        //         };

        //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        //        var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
        //            expires: DateTime.Now.Add(new TimeSpan(0, 0, 10)), signingCredentials: credentials);
        //        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        //    }

        //    // GET api/<UserController>/5
        //    [HttpGet("{id}")]
        //    public string Get(int id)
        //    {
        //        return "value";
        //    }

        //    // POST api/<UserController>
        //    [HttpPost]
        //    public void Post([FromBody] string value)
        //    {
        //    }

        //    // PUT api/<UserController>/5
        //    [HttpPut("{id}")]
        //    public void Put(int id, [FromBody] string value)
        //    {
        //    }

        //    // DELETE api/<UserController>/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id)
        //    {
        //    }
        //}
    }
}
