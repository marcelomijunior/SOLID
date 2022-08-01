using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface ILeilaoDAO : IQueryDAO<Leilao>, ICommandDAO<Leilao>
    {
    }
}
