using FluentValidation;
using LinqToDB;
using WEB.API.SQLSERVER.DOMINIO.Entidades;
using WEB.API.SQLSERVER.INFRA.Interfaces;

namespace WEB.API.SQLSERVER.INFRA.Repositorios
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private readonly IConexaoDB _conexao;
        private readonly IValidator<Carro> _validador;
        public CarroRepositorio(IConexaoDB conexao, IValidator<Carro> validador)
        {
            _conexao = conexao;
            _validador = validador;
        }

        public void Adicionar(Carro carro)
        {
            _validador.ValidateAndThrow(carro);

            carro.DataDeCadastro = DateTime.Now;
            _conexao.ConexaoSqlServer().Insert(carro);
        }

        public List<Carro> ObterTodos()
        {
            return Carro().ToList();
        }

        public Carro ObterPorId(int id)
        {
            return Carro().FirstOrDefault(x => x.Id == id) ??
                    throw new Exception($"Veículo não encontrado pelo indentificador [{id}]");
        }

        public void Atualizar(Carro carro)
        {
            _validador.ValidateAndThrow(carro);

            Carro().Where(x => x.Id == carro.Id)
                .Set(x => x.Marca, carro.Marca)
                .Set(x => x.Modelo, carro.Modelo)
                .Set(x => x.Versao, carro.Versao)
                .Set(x => x.Cor, carro.Cor)
                .Set(x => x.Combustivel, carro.Combustivel)
                .Set(x => x.Usado, carro.Usado)
                .Set(x => x.PrecoCusto, carro.PrecoCusto)
                .Set(x => x.PrecoVenda, carro.PrecoVenda)
                .Set(x => x.AnoFabricacao, carro.AnoFabricacao)
                .Set(x => x.AnoModelo, carro.AnoModelo)
                .Set(x => x.DataUltimaAtualizacao, DateTime.Now)
                .Update();
        }

        public void Remover(int id)
        {
            Carro().Where(x => x.Id == id).Delete();
        }

        private ITable<Carro> Carro()
        {
            return _conexao.ConexaoSqlServer().GetTable<Carro>();
        }
    }
}