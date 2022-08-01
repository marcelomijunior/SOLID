using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<Categoria> ConsultarCategorias();
        IEnumerable<Leilao> ConsultarLeiloes();
        Leilao ConsultarLeilaoPorId(int id);
        void CadastrarLeilao(Leilao leilao);
        void AtualizarLeilao(Leilao leilao);
        void RemoverLeilao(Leilao leilao);
        void IniciarPregaoDoLeilao(int id);
        void FinalizarPregaoDoLeilao(int id);
    }
}
