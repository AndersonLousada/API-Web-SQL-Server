using Microsoft.Extensions.DependencyInjection;
using WEB.API.SQLSERVER.DOMINIO;
using WEB.API.SQLSERVER.INFRA.ConexaoSqlServer;
using WEB.API.SQLSERVER.INFRA.Interfaces;
using WEB.API.SQLSERVER.INFRA.Repositorios;

namespace WEB.API.SQLSERVER.INFRA
{
    public static class ModuloInjecaoDeDependenciaInfra
    {
        public static void AddScopedInfra(this IServiceCollection service)
        {
            service.AddScoped<ICarroRepositorio, CarroRepositorio>();
            service.AddScoped<IUserRepositorio, UserRepositorio>();
            service.AddScoped<IConexaoDB, ConexaoDB>();
            service.AddScopedDominio();
        }
    }
}