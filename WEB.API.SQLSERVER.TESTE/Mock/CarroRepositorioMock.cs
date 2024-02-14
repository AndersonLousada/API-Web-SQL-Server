using FluentValidation;
using WEB.API.SQLSERVER.DOMINIO.Entidades;
using WEB.API.SQLSERVER.INFRA.Interfaces;

namespace WEB.API.SQLSERVER.TESTE.Mock
{
    public class CarroRepositorioMock : ICarroRepositorio
    {
        private List<Carro> _carros = new();
        private readonly IValidator<Carro> _validador;

        public CarroRepositorioMock(IValidator<Carro> validador)
        {
            _validador = validador;
        }
        
        public void Adicionar(Carro carro)
        {
            _validador.ValidateAndThrow(carro);
            _carros.Add(carro);
        }

        public void Atualizar(Carro carro)
        {
            var carroSalvo = ObterPorId((int)carro.Id);

            carroSalvo.DataDeCadastro = carro.DataDeCadastro;
            carroSalvo.DataUltimaAtualizacao = carro.DataUltimaAtualizacao;
            carroSalvo.Marca = carro.Marca;
            carroSalvo.Modelo = carro.Modelo;
            carroSalvo.Versao = carro.Versao;
            carroSalvo.Cor = carro.Cor;
            carroSalvo.Combustivel = carro.Combustivel;
            carroSalvo.Usado = carro.Usado;
            carroSalvo.PrecoCusto = carro.PrecoCusto;
            carroSalvo.PrecoVenda = carro.PrecoVenda;
            carroSalvo.AnoFabricacao = carro.AnoFabricacao;
            carroSalvo.AnoModelo = carro.AnoModelo;
        }

        public Carro ObterPorId(int id)
        {
            return _carros.FirstOrDefault(x => x.Id == id) ??
                    throw new Exception($"Veículo não encontrado pelo indentificador [{id}]");
        }

        public List<Carro> ObterTodos()
        {
            return _carros;
        }

        public void Remover(int id)
        {
            var carroSalvo = ObterPorId(id);
            _carros.Remove(carroSalvo);
        }
    }
}
