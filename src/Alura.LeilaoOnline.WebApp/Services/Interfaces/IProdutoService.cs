using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<Categoria> BuscarCategoriasComTotaisDosLeiloes();
        IEnumerable<Leilao> BuscarLeiloesPorTermo(string text);
        Categoria BuscarCategoriaPorIdComLeiloes(int id);
    }
}
