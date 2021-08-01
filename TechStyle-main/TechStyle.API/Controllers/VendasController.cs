using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStyle.Dominio.DTO;
using TechStyle.Dominio.Interface.Services;
using TechStyle.Dominio.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechStyle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendasService _vendaService;

        public VendasController(IVendasService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        public IEnumerable<Vendas> Get()
        {
            return _vendaService.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Vendas Get(int id)
        {
            return _vendaService.SelecionarPorId(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<ItemDeVendaDTO> dto)
        {
            var result = _vendaService.RealizarVenda(dto);
            if (result == true)
                return Ok("Venda Realizada");
            else
                return BadRequest("Um ou mais produtos estão em falta no estoque! Ou não estão ativos no sistema!");
        }
    }
}
