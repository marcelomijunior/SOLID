using Alura.LeilaoOnline.WebApp.Dados.Interfaces;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.Default
{
    public class DefaultProdutoService : IProdutoService
    {
        readonly ILeilaoDAO _leilaoDAO;
        readonly ICategoriaDAO _categoriaDAO;

        public DefaultProdutoService(ILeilaoDAO leilaoDAO, ICategoriaDAO categoriaDAO)
        {
            _leilaoDAO = leilaoDAO;
            _categoriaDAO = categoriaDAO;
        }

        public Categoria BuscarCategoriaPorIdComLeiloes(int id) => _categoriaDAO.BuscarCategoriaPorIdComLeiloes(id);

        public IEnumerable<Categoria> BuscarCategoriasComTotaisDosLeiloes()
            => _categoriaDAO.BuscarCategoriasComLeiloes()
                .Select(c => new CategoriaComInfoLeilao
                {
                    Id = c.Id,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    EmRascunho = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
                    EmPregao = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Pregao).Count(),
                    Finalizados = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Finalizado).Count(),
                });

        public IEnumerable<Leilao> BuscarLeiloesPorTermo(string termo) => _leilaoDAO.BuscarLeiloes().Where(c => c.Titulo.ToUpper().Contains(termo.ToUpper()) || c.Descricao.ToUpper().Contains(termo.ToUpper()) || c.Categoria.Descricao.ToUpper().Contains(termo.ToUpper()));

    }
}
