using Microsoft.AspNetCore.Mvc;
using WebApplication1.src.interfaces;
using WebApplication1.src.models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegister _registerService;

        public RegisterController(IRegister registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public ActionResult<Users> Register([FromBody] Users user)
        {
            var registeredUser = _registerService.Register(user.Email, user.Password, user.Name);
            return Ok(registeredUser);
        }
        //genera el token para guardar en el capo de user.token
/* private string GenerateJwtToken(Users user)
{
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes("Esto es un secreto");
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Issuer = "https://localhost:5001",
        Audience = "https://localhost:5001",
        Subject = new System.Security.Claims.ClaimsIdentity(new[]
        {
            new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new System.Security.Claims.Claim(ClaimTypes.Name, user.Name),
            new System.Security.Claims.Claim(ClaimTypes.Email, user.Email)
        }),
        Expires = DateTime.UtcNow.AddMinutes(30),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };
    var tokenGenerated = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(tokenGenerated);
}
 */    }
}
