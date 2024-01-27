using LinqToDB;
using LinqToDB.Data;
using WEB.API.SQLSERVER.INFRA.Interfaces;

namespace WEB.API.SQLSERVER.INFRA.ConexaoSqlServer
{
    public class ConexaoDB : IConexaoDB
    {
        public DataConnection ConexaoSqlServer()
        {
            const string CONNECTION_STRING = "CONNECTION_STRING";
            string stringConnection = Environment.GetEnvironmentVariable(CONNECTION_STRING)!;
            return new DataConnection(new DataOptions().UseSqlServer(stringConnection));
        }
    }
}
