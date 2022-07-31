using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface ILeilaoDAO
    {
        Leilao BuscarLeilaoPorId(int id);
        IEnumerable<Leilao> BuscarLeiloes();
        IEnumerable<Categoria> BuscarCategorias();
        void CriarLeilao(Leilao leilao);
        void AtualizarLeilao(Leilao leilao);
        void ExcluirLeilao(Leilao leilao);
    }
}
