using Alura.LeilaoOnline.WebApp.Dados.EFCore;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        readonly IProdutoService _produtoService;

        public HomeController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            var categorias = _produtoService.BuscarCategoriasComTotaisDosLeiloes();
            return View(categorias);
        }

        [Route("[controller]/StatusCode/{statusCode}")]
        public IActionResult StatusCodeError(int statusCode)
        {
            if (statusCode == 404) return View("404");
            return View(statusCode);
        }

        [Route("[controller]/Categoria/{categoria}")]
        public IActionResult Categoria(int categoria)
        {
            var categ = _produtoService.BuscarCategoriaPorIdComLeiloes(categoria);
            return View(categ);
        }

        [HttpPost]
        [Route("[controller]/Busca")]
        public IActionResult Busca(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = _produtoService.BuscarLeiloesPorTermo(termo);
            return View(leiloes);
        }
    }
}
