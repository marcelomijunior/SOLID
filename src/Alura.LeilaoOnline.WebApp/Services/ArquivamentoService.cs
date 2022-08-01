using Alura.LeilaoOnline.WebApp.Dados.Interfaces;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services.Default;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public class ArquivamentoService : IAdminService
    {
        readonly IAdminService _adminService;

        public ArquivamentoService(ILeilaoDAO leilaoDAO)
        {
            _adminService = new DefaultAdminService(leilaoDAO);
        }

        public void AtualizarLeilao(Leilao leilao) => _adminService.AtualizarLeilao(leilao);

        public void CadastrarLeilao(Leilao leilao) => _adminService.CadastrarLeilao(leilao);

        public IEnumerable<Categoria> ConsultarCategorias() => _adminService.ConsultarCategorias();

        public Leilao ConsultarLeilaoPorId(int id)
        {
            return _adminService.ConsultarLeilaoPorId(id);
        }

        public IEnumerable<Leilao> ConsultarLeiloes()
        {
            return _adminService.ConsultarLeiloes();
        }

        public void FinalizarPregaoDoLeilao(int id)
        {
            _adminService.FinalizarPregaoDoLeilao(id);
        }

        public void IniciarPregaoDoLeilao(int id)
        {
            _adminService.IniciarPregaoDoLeilao(id);
        }

        public void RemoverLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Arquivado;
                _adminService.AtualizarLeilao(leilao);
            }
        }
    }
}
