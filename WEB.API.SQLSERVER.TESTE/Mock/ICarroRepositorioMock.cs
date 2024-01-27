using WEB.API.SQLSERVER.DOMINIO.Entidades;

namespace WEB.API.SQLSERVER.TESTE.Mock
{
    public interface ICarroRepositorioMock
    {
        List<Carro> ObterTodos();
        Carro ObterPorId(int id);
        void Remover(int id);
        void Adicionar(Carro carro);
        void Atualizar(Carro carro);
    }
}
