using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WEB.API.SQLSERVER.DOMINIO.Entidades;
using WEB.API.SQLSERVER.DOMINIO.Validadores;

namespace WEB.API.SQLSERVER.DOMINIO
{
    public static class ModuloInjecaoDeDependenciaDominio
    {
        public static void AddScopedDominio(this IServiceCollection service)
        {
            service.AddScoped<IValidator<Carro>, ValidadorCarro>();
        }
    }
}