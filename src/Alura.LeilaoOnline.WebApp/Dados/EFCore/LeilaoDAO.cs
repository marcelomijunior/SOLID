using Alura.LeilaoOnline.WebApp.Dados.Interfaces;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class LeilaoDAO : ILeilaoDAO
    {
        private readonly AppDbContext _context;

        public LeilaoDAO()
        {
            _context = new AppDbContext();
        }

        public Leilao BuscarLeilaoPorId(int id) => _context.Leiloes.Find(id);

        public IEnumerable<Leilao> BuscarLeiloes() => _context.Leiloes.Include(x => x.Categoria).ToList();

        public IEnumerable<Categoria> BuscarCategorias() => _context.Categorias.ToList();

        public void CriarLeilao(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }

        public void AtualizarLeilao(Leilao leilao)
        {
            _context.Update(leilao);
            _context.SaveChanges();
        }

        public void ExcluirLeilao(Leilao leilao)
        {
            _context.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
