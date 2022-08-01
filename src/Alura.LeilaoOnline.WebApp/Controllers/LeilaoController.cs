using Alura.LeilaoOnline.WebApp.Dados.Interfaces;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using System;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class LeilaoController : Controller
    {
        readonly IAdminService _adminService;

        public LeilaoController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            var leiloes = _adminService.ConsultarLeiloes();
            return View(leiloes);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            ViewData["Categorias"] = _adminService.ConsultarCategorias();
            ViewData["Operacao"] = "Inclusão";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Insert(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _adminService.CadastrarLeilao(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _adminService.ConsultarCategorias();
            ViewData["Operacao"] = "Inclusão";
            return View("Form", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categorias"] = _adminService.ConsultarCategorias();
            ViewData["Operacao"] = "Edição";
            var leilao = _adminService.ConsultarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            return View("Form", leilao);
        }

        [HttpPost]
        public IActionResult Edit(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _adminService.AtualizarLeilao(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _adminService.ConsultarCategorias();
            ViewData["Operacao"] = "Edição";
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Inicia(int id)
        {
            var leilao = _adminService.ConsultarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            _adminService.AtualizarLeilao(leilao);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finaliza(int id)
        {
            var leilao = _adminService.ConsultarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            _adminService.FinalizarPregaoDoLeilao(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var leilao = _adminService.ConsultarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            _adminService.RemoverLeilao(leilao);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Pesquisa(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = _adminService.ConsultarLeiloes()
                .Where(l => string.IsNullOrWhiteSpace(termo) ||
                    l.Titulo.ToUpper().Contains(termo.ToUpper()) ||
                    l.Descricao.ToUpper().Contains(termo.ToUpper()) ||
                    l.Categoria.Descricao.ToUpper().Contains(termo.ToUpper())
                );
            return View("Index", leiloes);
        }
    }
}
