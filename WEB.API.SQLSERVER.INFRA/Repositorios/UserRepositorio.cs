using LinqToDB;
using WEB.API.SQLSERVER.DOMINIO.Entidades;
using WEB.API.SQLSERVER.INFRA.Interfaces;

namespace WEB.API.SQLSERVER.INFRA.Repositorios
{
    public class UserRepositorio : IUserRepositorio
    {
        private readonly IConexaoDB _conexao;

        public UserRepositorio(IConexaoDB conexao)
        {
            _conexao = conexao;
        }

        public void Adicionar(User user)
        {
            _conexao.ConexaoSqlServer().Insert(user);
        }

        public User ObterPorUserName(string username)
        {
            var userDataBase = _conexao.ConexaoSqlServer().GetTable<User>().FirstOrDefault(x => x.UserName == username) ??
                    throw new Exception($"Usuário ou senha não autenticados");

            return userDataBase;
        }

        public List<User> ObterTodos()
        {
            return _conexao.ConexaoSqlServer().GetTable<User>().ToList();
        }
    }
}