using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WEB.API.SQLSERVER.DOMINIO.Entidades;
using WEB.API.SQLSERVER.DOMINIO.Validadores;
using WEB.API.SQLSERVER.INFRA.Interfaces;
using WEB.API.SQLSERVER.TESTE.Mock;

namespace WEB.API.SQLSERVER.TESTE
{
    public class TesteBase
    {
        protected readonly IServiceCollection _service;
        public TesteBase()
        {
            _service = DefinirInjecaoDeDependencia();
        }

        private IServiceCollection DefinirInjecaoDeDependencia()
        {
            var services = new ServiceCollection();
            services.AddScoped<ICarroRepositorio, CarroRepositorioMock>();
            services.AddScoped<IValidator<Carro>, ValidadorCarro>();
            return services;
        }
    }
}