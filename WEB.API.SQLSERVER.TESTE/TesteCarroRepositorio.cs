using Microsoft.Extensions.DependencyInjection;
using WEB.API.SQLSERVER.DOMINIO.Entidades;
using WEB.API.SQLSERVER.DOMINIO.Enums;
using WEB.API.SQLSERVER.INFRA.Interfaces;

namespace WEB.API.SQLSERVER.TESTE
{
    public class TesteCarroRepositorio : TesteBase
    {
        private readonly ICarroRepositorio _repositorio;
        public TesteCarroRepositorio()
        {
            var provider = _service.BuildServiceProvider();
            using var scope = provider.CreateScope();
            _repositorio = scope.ServiceProvider.GetRequiredService<ICarroRepositorio>();
        }

        [Fact]
        public void obterTodos_deve_retornar_uma_lista()
        {
            CriarRegistros();

            var result = _repositorio.ObterTodos();

            var listaEsperada = ObterListaDeCarros();
            Assert.Equal(listaEsperada.Count, result.Count);
            Assert.Equivalent(listaEsperada, result);
        }

        [Fact]
        public void obterPorId_deve_retornar_um_registro_com_id_igual_ao_informado()
        {
            const int id = 1;
            CriarRegistros();

            var atual = _repositorio.ObterPorId(id);

            var esperado = ObterListaDeCarros().FirstOrDefault(x => x.Id.Equals(id));
            Assert.Equivalent(esperado, atual);
        }

        [Fact]
        public void remover_deve_lancar_excessao_ao_informar_id_invalido()
        {
            const int id = 0;
            var result = Assert.ThrowsAny<Exception>(() => _repositorio.Remover(id));
            Assert.Equal($"Veículo não encontrado pelo indentificador [{id}]", result.Message);
        }

        [Fact]
        public void remover_nao_deve_lancar_excessao_ao_informar_id_valido()
        {
            const int id = 1;
            CriarRegistros();

            Exception ex = Record.Exception(() => _repositorio.Remover(id));

            Assert.Null(ex);
        }

        [Fact]
        public void remover_deve_excluir_registro_ao_informar_id_valido()
        {
            CriarRegistros();

            const int id = 1;
            _repositorio.Remover(id);

            bool existeRegistro = _repositorio.ObterTodos().Any(x => x.Id == id);
            Assert.False(existeRegistro);
        }

        [Fact]
        public void adicionar_deve_lancar_excessao_ao_informar_anoFabricacao_invalido()
        {
            var veiculoParaCadastro = new Carro
            {
                DataDeCadastro = new DateTime(2024, 05, 10, 0, 0, 0),
                DataUltimaAtualizacao = null,
                Marca = "Fiat",
                Modelo = "147",
                Versao = "GL",
                Cor = "Vermelho",
                Combustivel = ECombustivel.Gasolina,
                Usado = true,
                PrecoCusto = 12550.00m,
                PrecoVenda = 35550.00m,
                AnoFabricacao = new DateTime(2013, 06, 09, 0, 0, 0),
                AnoModelo = new DateTime(1987, 01, 01, 0, 0, 0)
            };

            var result = Assert.ThrowsAny<Exception>(() => _repositorio.Adicionar(veiculoParaCadastro));

            Assert.True(result?.Message.Contains("Não é possível cadastrar véículo com ano de fabricação maior que dez anos"));
        }

        [Fact]
        public void adicionar_deve_lancar_excessao_ao_informar_anoModelo_invalido()
        {
            var veiculoParaCadastro = new Carro
            {
                DataDeCadastro = new DateTime(2024, 05, 10, 0, 0, 0),
                DataUltimaAtualizacao = null,
                Marca = "Fiat",
                Modelo = "147",
                Versao = "GL",
                Cor = "Vermelho",
                Combustivel = ECombustivel.Gasolina,
                Usado = true,
                PrecoCusto = 12550.00m,
                PrecoVenda = 35550.00m,
                AnoFabricacao = new DateTime(2024, 06, 09, 0, 0, 0),
                AnoModelo = new DateTime(1987, 01, 01, 0, 0, 0)
            };

            var result = Assert.ThrowsAny<Exception>(() => _repositorio.Adicionar(veiculoParaCadastro));

            Assert.True(result?.Message.Contains("Ano modelo não deve ser menor que o ano de fabricação"));

        }

        [Fact]
        public void adicionar_deve_lancar_excessao_ao_nao_informar_marca()
        {
            var veiculoParaCadastro = new Carro
            {
                DataDeCadastro = new DateTime(2024, 05, 10, 0, 0, 0),
                DataUltimaAtualizacao = null,
                Modelo = "147",
                Versao = "GL",
                Cor = "Vermelho",
                Combustivel = ECombustivel.Gasolina,
                Usado = true,
                PrecoCusto = 12550.00m,
                PrecoVenda = 35550.00m,
                AnoFabricacao = new DateTime(2024, 06, 09, 0, 0, 0),
                AnoModelo = new DateTime(2025, 01, 01, 0, 0, 0)
            };

            var result = Assert.ThrowsAny<Exception>(() => _repositorio.Adicionar(veiculoParaCadastro));

            Assert.True(result?.Message.Contains("Marca deve ser informada"));
        }

        [Fact]
        public void adicionar_deve_lancar_excessao_ao_nao_informar_modelo()
        {
            var veiculoParaCadastro = new Carro
            {
                DataDeCadastro = new DateTime(2024, 05, 10, 0, 0, 0),
                DataUltimaAtualizacao = null,
                Marca = "Fiat",
                Versao = "GL",
                Cor = "Vermelho",
                Combustivel = ECombustivel.Gasolina,
                Usado = true,
                PrecoCusto = 12550.00m,
                PrecoVenda = 35550.00m,
                AnoFabricacao = new DateTime(2024, 06, 09, 0, 0, 0),
                AnoModelo = new DateTime(2025, 01, 01, 0, 0, 0)
            };

            var result = Assert.ThrowsAny<Exception>(() => _repositorio.Adicionar(veiculoParaCadastro));

            Assert.True(result?.Message.Contains("Modelo deve ser informado"));

        }

        [Fact]
        public void adicionar_deve_lancar_excessao_ao_nao_informar_cor()
        {
            var veiculoParaCadastro = new Carro
            {
                DataDeCadastro = new DateTime(2024, 05, 10, 0, 0, 0),
                DataUltimaAtualizacao = null,
                Marca = "Fiat",
                Modelo = "174",
                Versao = "GL",
                Combustivel = ECombustivel.Gasolina,
                Usado = true,
                PrecoCusto = 12550.00m,
                PrecoVenda = 35550.00m,
                AnoFabricacao = new DateTime(2024, 06, 09, 0, 0, 0),
                AnoModelo = new DateTime(2025, 01, 01, 0, 0, 0)
            };

            var result = Assert.ThrowsAny<Exception>(() => _repositorio.Adicionar(veiculoParaCadastro));
            Assert.True(result?.Message.Contains("Cor deve ser informada"));
        }

        [Fact]
        public void adicionar_deve_lancar_excessao_ao_informar_precoVenda_invalido()
        {
            var veiculoParaCadastro = new Carro
            {
                DataDeCadastro = new DateTime(2024, 05, 10, 0, 0, 0),
                DataUltimaAtualizacao = null,
                Marca = "Fiat",
                Modelo = "174",
                Cor = "Vermelho",
                Versao = "GL",
                Combustivel = ECombustivel.Gasolina,
                Usado = true,
                PrecoCusto = 12550.00m,
                PrecoVenda = 29999.00m,
                AnoFabricacao = new DateTime(2024, 06, 09, 0, 0, 0),
                AnoModelo = new DateTime(2025, 01, 01, 0, 0, 0)
            };

            var result = Assert.ThrowsAny<Exception>(() => _repositorio.Adicionar(veiculoParaCadastro));
            Assert.True(result?.Message.Contains("Não é permitido cadastrar veículos com valor venal menor que R$30.000,00"));
        }

        [Fact]
        public void adicionar_deve_lancar_excessao_ao_nao_informar_precoCusto()
        {
            var veiculoParaCadastro = new Carro
            {
                DataDeCadastro = new DateTime(2024, 05, 10, 0, 0, 0),
                DataUltimaAtualizacao = null,
                Marca = "Fiat",
                Modelo = "174",
                Cor = "Vermelho",
                Versao = "GL",
                Combustivel = ECombustivel.Gasolina,
                Usado = true,
                PrecoVenda = 35550.00m,
                AnoFabricacao = new DateTime(2024, 06, 09, 0, 0, 0),
                AnoModelo = new DateTime(2025, 01, 01, 0, 0, 0)
            };

            var result = Assert.ThrowsAny<Exception>(() => _repositorio.Adicionar(veiculoParaCadastro));
            Assert.True(result?.Message.Contains("Custo deve ser informado"));
        }

        [Fact]
        public void adicionar_deve_lancar_excessao_obtendo_todas_as_validacoes()
        {
            var veiculoParaCadastro = new Carro
            {
                DataDeCadastro = new DateTime(2024, 05, 10, 0, 0, 0),
                DataUltimaAtualizacao = null,
                Combustivel = ECombustivel.Gasolina,
                Usado = true,
                PrecoVenda = 29999.00m,
                AnoFabricacao = new DateTime(2013, 06, 09, 0, 0, 0),
                AnoModelo = new DateTime(2012, 01, 01, 0, 0, 0)
            };

            var result = Assert.ThrowsAny<Exception>(() => _repositorio.Adicionar(veiculoParaCadastro));

            Assert.True(result?.Message.Contains("Custo deve ser informado"));
            Assert.True(result?.Message.Contains("Não é permitido cadastrar veículos com valor venal menor que R$30.000,00"));
            Assert.True(result?.Message.Contains("Cor deve ser informada"));
            Assert.True(result?.Message.Contains("Modelo deve ser informado"));
            Assert.True(result?.Message.Contains("Marca deve ser informada"));
            Assert.True(result?.Message.Contains("Ano modelo não deve ser menor que o ano de fabricação"));
            Assert.True(result?.Message.Contains("Não é possível cadastrar véículo com ano de fabricação maior que dez anos"));
        }

        [Fact]
        public void adicionar_nao_deve_lancar_excessao_ao_informar_novo_registro_valido()
        {
            var veiculoParaCadastro = new Carro
            {
                DataDeCadastro = new DateTime(2024, 05, 10, 0, 0, 0),
                DataUltimaAtualizacao = null,
                Marca = "Fiat",
                Modelo = "174",
                Cor = "Vermelho",
                Versao = "GL",
                Combustivel = ECombustivel.Gasolina,
                Usado = true,
                PrecoVenda = 35550.00m,
                PrecoCusto = 20000.00m,
                AnoFabricacao = new DateTime(2024, 06, 09, 0, 0, 0),
                AnoModelo = new DateTime(2025, 01, 01, 0, 0, 0)
            };

            Exception ex = Record.Exception(() => _repositorio.Adicionar(veiculoParaCadastro));

            Assert.Null(ex);
        }

        [Fact]
        public void adicionar_deve_criar_registro_na_base()
        {
            const int id = 1;
            var veiculoParaCadastro = new Carro
            {
                Id = id,
                DataDeCadastro = new DateTime(2024, 05, 10, 0, 0, 0),
                DataUltimaAtualizacao = null,
                Marca = "Fiat",
                Modelo = "Toro",
                Cor = "Vermelho",
                Versao = "Ultra",
                Combustivel = ECombustivel.Flex,
                Usado = true,
                PrecoVenda = 35550.00m,
                PrecoCusto = 20000.00m,
                AnoFabricacao = new DateTime(2024, 06, 09, 0, 0, 0),
                AnoModelo = new DateTime(2024, 01, 01, 0, 0, 0)
            };

            Exception ex = Record.Exception(() => _repositorio.Adicionar(veiculoParaCadastro));
            Assert.Null(ex);

            bool possuiRegistro = _repositorio.ObterTodos().Any(x => x.Id.Equals(id));
            Assert.True(possuiRegistro);
        }

        [Fact]
        public void atualizar_deve_modificar_um_registro_na_base()
        {
            CriarRegistros();

            const int id = 1;
            const string cor = "Prata";
            const string versao = "LTZ";
            var veiculoParaAtualizar = new Carro
            {
                Id = id,
                DataDeCadastro = new DateTime(2024, 05, 10, 0, 0, 0),
                DataUltimaAtualizacao = null,
                Marca = "Chevrolet",
                Modelo = "Onix",
                Cor = cor,
                Versao = versao,
                Combustivel = ECombustivel.Gasolina,
                Usado = true,
                PrecoVenda = 89000.00m,
                PrecoCusto = 80000.00m,
                AnoFabricacao = new DateTime(2024, 06, 09, 0, 0, 0),
                AnoModelo = new DateTime(2025, 01, 01, 0, 0, 0)
            };

            Exception ex = Record.Exception(() => _repositorio.Atualizar(veiculoParaAtualizar));
            Assert.Null(ex);

            var registroBase = _repositorio.ObterPorId(id);
            Assert.Equal(veiculoParaAtualizar.Cor, registroBase.Cor);
            Assert.Equal(veiculoParaAtualizar.Versao, registroBase.Versao);
        }

        private void CriarRegistros()
        {
            ObterListaDeCarros().ForEach(_repositorio.Adicionar);
        }

        private List<Carro> ObterListaDeCarros()
        {
            return new List<Carro>()
            {
                new Carro
                {
                    Id = 1,
                    DataDeCadastro = new DateTime(2024, 05, 10, 0, 0, 0),
                    DataUltimaAtualizacao = null,
                    Marca = "Chevrolet",
                    Modelo = "Onix",
                    Cor = "Branco",
                    Versao = "Premier",
                    Combustivel = ECombustivel.Gasolina,
                    Usado = true,
                    PrecoVenda = 89000.00m,
                    PrecoCusto = 80000.00m,
                    AnoFabricacao = new DateTime(2024, 06, 09, 0, 0, 0),
                    AnoModelo = new DateTime(2025, 01, 01, 0, 0, 0)
                },
                new Carro
                {
                    Id = 2,
                    DataDeCadastro = new DateTime(2024, 05, 10, 0, 0, 0),
                    DataUltimaAtualizacao = null,
                    Marca = "Fiat",
                    Modelo = "Toro",
                    Cor = "Vermelho",
                    Versao = "Ultra",
                    Combustivel = ECombustivel.Flex,
                    Usado = true,
                    PrecoVenda = 120000.00m,
                    PrecoCusto = 110000.00m,
                    AnoFabricacao = new DateTime(2024, 06, 09, 0, 0, 0),
                    AnoModelo = new DateTime(2024, 01, 01, 0, 0, 0)
                }
            };
        }
    }
}