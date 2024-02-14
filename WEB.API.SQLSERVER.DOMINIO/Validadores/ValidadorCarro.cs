using FluentValidation;
using WEB.API.SQLSERVER.DOMINIO.Entidades;

namespace WEB.API.SQLSERVER.DOMINIO.Validadores
{
    public class ValidadorCarro : AbstractValidator<Carro>
    {
        public ValidadorCarro()
        {
            Validar();
        }

        private void Validar()
        {
            RuleFor(x => x.AnoFabricacao)
                .Must(CalcularData)
                .WithMessage("Não é possível cadastrar véículo com ano de fabricação maior que dez anos");

            RuleFor(x => x)
                .Must(ValidarAnoModelo)
                .WithMessage("Ano modelo não deve ser menor que o ano de fabricação");

            RuleFor(x => x.Marca)
                .NotEmpty()
                .WithMessage("Marca deve ser informada");

            RuleFor(x => x.Modelo)
                .NotEmpty()
                .WithMessage("Modelo deve ser informado");

            RuleFor(x => x.Cor)
                .NotEmpty()
                .WithMessage("Cor deve ser informada");

            RuleFor(x => x.PrecoVenda)
                .GreaterThanOrEqualTo(30000)
                .WithMessage("Não é permitido cadastrar veículos com valor venal menor que R$30.000,00");

            RuleFor(x => x.PrecoCusto)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Custo deve ser informado");
        }

        private bool ValidarAnoModelo(Carro carro)
        {
            return carro.AnoFabricacao.Year <= carro.AnoModelo.Year;
        }

        private bool CalcularData(DateTime anoFabricacao)
        {
            const int QUANTIDADE_MAXIMA = 10;
            int diferenca = DateTime.Now.Year - anoFabricacao.Year;
            return diferenca <= QUANTIDADE_MAXIMA;
        }
    }
}
