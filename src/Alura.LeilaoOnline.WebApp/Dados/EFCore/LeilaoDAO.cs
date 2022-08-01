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

        public LeilaoDAO(AppDbContext context)
        {
            _context = context;
        }

        public Leilao ConsultarPorId(int id) => _context.Leiloes.Find(id);

        public IEnumerable<Leilao> ConsultarTodos() => _context.Leiloes.Include(x => x.Categoria).ToList();

        public void Cadastrar(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }

        public void Atualizar(Leilao leilao)
        {
            _context.Update(leilao);
            _context.SaveChanges();
        }

        public void Remover(Leilao leilao)
        {
            _context.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
