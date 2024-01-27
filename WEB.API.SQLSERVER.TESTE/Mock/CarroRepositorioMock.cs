using WEB.API.SQLSERVER.DOMINIO.Entidades;
using WEB.API.SQLSERVER.DOMINIO.Enums;

namespace WEB.API.SQLSERVER.TESTE.Mock
{
    public class CarroRepositorioMock : ICarroRepositorioMock
    {
        public void Adicionar(Carro carro)
        {
            ObterListaDeCarros().Add(carro);
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
            return ObterListaDeCarros().FirstOrDefault(x => x.Id == id) ??
                    throw new Exception($"Veículo não encontrado pelo indentificador [{id}]");
        }

        public List<Carro> ObterTodos()
        {
            return ObterListaDeCarros();
        }

        public void Remover(int id)
        {
            var carroSalvo = ObterPorId(id);
            ObterListaDeCarros().Remove(carroSalvo);
        }

        private List<Carro> ObterListaDeCarros()
        {
            return new List<Carro>()
            {
                new Carro
                {
                    Id = 1,
                    DataDeCadastro = DateTime.Now,
                    DataUltimaAtualizacao = null,
                    Marca = "Fiat",
                    Modelo = "147",
                    Versao = "GL",
                    Cor = "Vermelho",
                    Combustivel = ECombustivel.Gasolina,
                    Usado = true,
                    PrecoCusto = 12550.00m,
                    PrecoVenda = 35550.00m,
                    AnoFabricacao = new DateTime(1987, 06, 09),
                    AnoModelo = new DateTime(1987, 01, 01)
                },
                new Carro
                {
                    Id = 2,
                    DataDeCadastro = DateTime.Now,
                    DataUltimaAtualizacao = null,
                    Marca = "Chevrolet",
                    Modelo = "Opala",
                    Versao = "Diplomata",
                    Cor = "Azul",
                    Combustivel = ECombustivel.Gasolina,
                    Usado = true,
                    PrecoCusto = 22550.00m,
                    PrecoVenda = 45550.00m,
                    AnoFabricacao = new DateTime(1991, 06, 09),
                    AnoModelo = new DateTime(1991, 01, 01)
                }
            };
        }
    }
}
