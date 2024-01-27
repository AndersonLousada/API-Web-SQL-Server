using LinqToDB.Data;

namespace WEB.API.SQLSERVER.INFRA.Interfaces
{
    public interface IConexaoDB
    {
        DataConnection ConexaoSqlServer();
    }
}
