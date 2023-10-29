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
    }
}
