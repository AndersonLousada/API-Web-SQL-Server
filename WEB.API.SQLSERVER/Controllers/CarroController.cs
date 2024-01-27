using Microsoft.AspNetCore.Mvc;
using WEB.API.SQLSERVER.DOMINIO.Entidades;
using WEB.API.SQLSERVER.INFRA.Interfaces;

namespace WEB.API.SQLSERVER.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepositorio _repositorio;
        public CarroController(ICarroRepositorio carro)
        {
            _repositorio = carro;
        }

        [HttpGet]
        public OkObjectResult Carro()
        {
            var carros = _repositorio.ObterTodos();

            return Ok(carros);
        }

        [HttpGet("{id}")]
        public OkObjectResult ObterPorId(int id)
        {
            var carro = _repositorio.ObterPorId(id);

            return Ok(carro);
        }

        [HttpDelete("{id}")]
        public NoContentResult Remover(int id)
        {
            _repositorio.Remover(id);

            return NoContent();
        }

        [HttpPost]
        public NoContentResult Adicionar([FromBody] Carro carro)
        {
            _repositorio.Adicionar(carro);

            return NoContent();
        }

        [HttpPatch]
        public NoContentResult Atualizar([FromBody] Carro carro)
        {
            _repositorio.Atualizar(carro);

            return NoContent();
        }
    }
}