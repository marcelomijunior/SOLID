using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface IQueryDAO<T> where T : class
    {
        T ConsultarPorId(int id);
        IEnumerable<T> ConsultarTodos();
    }
}
