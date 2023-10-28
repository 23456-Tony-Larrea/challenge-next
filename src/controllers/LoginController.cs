
using Microsoft.AspNetCore.Mvc;
using WebApplication1.src.interfaces;
using WebApplication1.src.models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _loginService;

        public LoginController(ILogin loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public ActionResult<Users> Login([FromBody] Users user)
        {
            var loggedUser = _loginService.Login(user.Email, user.Password);
            if (loggedUser != null)
            {
            return Ok("Inicio de sesión exitoso"); 
                    }
            else
            {
                // Autenticación fallida, devolver un mensaje de error
                return BadRequest("Credenciales incorrectas");
            }
        }
    }
}
