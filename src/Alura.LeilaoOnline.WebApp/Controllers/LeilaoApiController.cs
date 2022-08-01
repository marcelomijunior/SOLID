﻿using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados.Interfaces;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        readonly IAdminService _adminService;

        public LeilaoApiController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = _adminService.ConsultarLeiloes();
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = _adminService.ConsultarLeilaoPorId(id);
            if (leilao == null)
            {
                return NotFound();
            }
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            _adminService.CadastrarLeilao(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            _adminService.AtualizarLeilao(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = _adminService.ConsultarLeilaoPorId(id);
            if (leilao == null)
            {
                return NotFound();
            }
            _adminService.RemoverLeilao(leilao);
            return NoContent();
        }

        [HttpPost("{id}/pregao")]
        public IActionResult EndPointIniciaPregao(int id)
        {
            var leilao = _adminService.ConsultarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            _adminService.IniciarPregaoDoLeilao(id);
            return Ok();
        }

        [HttpDelete("{id}/pregao")]
        public IActionResult EndPointFinalizaPregao(int id)
        {
            var leilao = _adminService.ConsultarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            _adminService.FinalizarPregaoDoLeilao(id);
            return Ok();
        }
    }
}
