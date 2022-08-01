using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class CategoriaDAO : ICategoriaDAO
    {
        private readonly AppDbContext _context;

        public CategoriaDAO(AppDbContext context)
        {
            _context = context;
        }

        public Categoria ConsultarPorId(int id) => _context.Categorias.Where(x => x.Id == id).Include(x => x.Leiloes).FirstOrDefault();

        public IEnumerable<Categoria> ConsultarTodos() => _context.Categorias.Include(x => x.Leiloes).ToList();
    }
}
