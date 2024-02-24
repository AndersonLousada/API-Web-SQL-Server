using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB.API.SQLSERVER.Auth;
using WEB.API.SQLSERVER.DOMINIO.Entidades;
using WEB.API.SQLSERVER.INFRA.Interfaces;

namespace WEB.API.SQLSERVER.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositorio _repositorio;

        public UserController(IUserRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpPost]
        public NoContentResult Adicionar(User user)
        {
            user.Password = Cryptography.Criptografar(user.Password);
            _repositorio.Adicionar(user);

            return NoContent();
        }

        [HttpGet]
        public OkObjectResult ObterTodos()
        {
            var users = _repositorio.ObterTodos();

            return Ok(users);
        }
    }
}
