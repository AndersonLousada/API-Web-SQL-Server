using WEB.API.SQLSERVER.DOMINIO.Entidades;

namespace WEB.API.SQLSERVER.INFRA.Interfaces
{
    public interface ICarroRepositorio
    {
        List<Carro> ObterTodos();
        Carro ObterPorId(int id);
        void Remover(int id);
        void Adicionar(Carro carro);
        void Atualizar(Carro carro);
    }
}