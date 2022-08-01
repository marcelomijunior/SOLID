using Alura.LeilaoOnline.WebApp.Dados.Interfaces;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Default
{
    public class DefaultAdminService : IAdminService
    {
        readonly ILeilaoDAO _leilaoDAO;
        readonly ICategoriaDAO _categoriaDAO;

        public DefaultAdminService(ILeilaoDAO leilaoDAO, ICategoriaDAO categoriaDAO)
        {
            _leilaoDAO = leilaoDAO;
            _categoriaDAO = categoriaDAO;
        }

        public void AtualizarLeilao(Leilao leilao) => _leilaoDAO.Atualizar(leilao);

        public void CadastrarLeilao(Leilao leilao) => _leilaoDAO.Cadastrar(leilao);

        public IEnumerable<Categoria> ConsultarCategorias() => _categoriaDAO.ConsultarTodos();

        public Leilao ConsultarLeilaoPorId(int id) => _leilaoDAO.ConsultarPorId(id);

        public IEnumerable<Leilao> ConsultarLeiloes() => _leilaoDAO.ConsultarTodos();

        public void FinalizarPregaoDoLeilao(int id)
        {
            var leilao = _leilaoDAO.ConsultarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                _leilaoDAO.Atualizar(leilao);
            }
        }

        public void IniciarPregaoDoLeilao(int id)
        {
            var leilao = _leilaoDAO.ConsultarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                _leilaoDAO.Atualizar(leilao);
            }
        }

        public void RemoverLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao) _leilaoDAO.Remover(leilao);
        }
    }
}
