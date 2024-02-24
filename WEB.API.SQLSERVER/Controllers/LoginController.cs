using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB.API.SQLSERVER.Auth;
using WEB.API.SQLSERVER.DOMINIO.Entidades;
using WEB.API.SQLSERVER.INFRA.Interfaces;

namespace WEB.API.SQLSERVER.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepositorio _repositorio;
        private readonly TokenService _tokenService;

        public LoginController(IUserRepositorio repositorio, TokenService tokenService)
        {
            _repositorio = repositorio;
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public OkObjectResult Login([FromBody] User user)
        {
            var userDataBase = _repositorio.ObterPorUserName(user.UserName);
            string password = Cryptography.Criptografar(user.Password);

            if (!password.Equals(userDataBase.Password))
                throw new Exception($"Usuário ou senha não autenticados");

            var token = _tokenService.GetToken(userDataBase);

            return Ok(new
            {
                Id = userDataBase.Id,
                UserName = userDataBase.UserName,
                Token = token,
            });
        }
    }
}