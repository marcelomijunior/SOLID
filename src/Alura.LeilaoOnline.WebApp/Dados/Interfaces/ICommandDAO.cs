namespace Alura.LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface ICommandDAO<T> where T : class
    {
        void Atualizar(T obj);
        void Cadastrar(T obj);
        void Remover(T obj);
    }
}
