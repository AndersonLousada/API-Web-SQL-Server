using WEB.API.SQLSERVER.DOMINIO.Entidades;

namespace WEB.API.SQLSERVER.INFRA.Interfaces
{
    public interface IUserRepositorio
    {
        void Adicionar(User user);
        User ObterPorUserName(string username);
        List<User> ObterTodos();
    }
}