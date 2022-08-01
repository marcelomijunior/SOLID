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

        public DefaultAdminService(ILeilaoDAO leilaoDAO)
        {
            _leilaoDAO = leilaoDAO;
        }

        public void AtualizarLeilao(Leilao leilao) => _leilaoDAO.AtualizarLeilao(leilao);

        public void CadastrarLeilao(Leilao leilao) => _leilaoDAO.CriarLeilao(leilao);

        public IEnumerable<Categoria> ConsultarCategorias() => _leilaoDAO.BuscarCategorias();

        public Leilao ConsultarLeilaoPorId(int id) => _leilaoDAO.BuscarLeilaoPorId(id);

        public IEnumerable<Leilao> ConsultarLeiloes() => _leilaoDAO.BuscarLeiloes();

        public void FinalizarPregaoDoLeilao(int id)
        {
            var leilao = _leilaoDAO.BuscarLeilaoPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                _leilaoDAO.AtualizarLeilao(leilao);
            }
        }

        public void IniciarPregaoDoLeilao(int id)
        {
            var leilao = _leilaoDAO.BuscarLeilaoPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                _leilaoDAO.AtualizarLeilao(leilao);
            }
        }

        public void RemoverLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
                _leilaoDAO.ExcluirLeilao(leilao);
        }
    }
}
