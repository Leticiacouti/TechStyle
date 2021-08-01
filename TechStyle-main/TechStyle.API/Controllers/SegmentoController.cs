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
    public class SegmentoController : ControllerBase
    {
        private readonly ISegmentoService _segmentoService;

        public SegmentoController(ISegmentoService segmentoService)
        {
            _segmentoService = segmentoService;
        }

        [HttpGet]
        public IEnumerable<Segmento> Get()
        {
            return _segmentoService.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Segmento Get(int id)
        {
            return _segmentoService.SelecionarPorId(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SegmentoDTO dto)
        {
            var result = _segmentoService.Cadastrar(dto);
            if (result == true)
            {
                return Ok("Segmento cadastrado!");
            }
            else
            {
                return BadRequest("Ocorreu um erro ao cadastrar!");
            }
        }

        [HttpPut("{id}/AlterarDados")]
        public IActionResult PutAlterarDados(int id, [FromBody] SegmentoDTO dto)
        {
            _segmentoService.Alterar(id, dto);
            return Ok("Segmento alterado com sucesso!");
        }

        [HttpPut("{id}/AlterarStatus")]
        public IActionResult PutAlterarStatus(int id)
        {
            _segmentoService.AlterarStatus(id);
            return Ok("Status do segmento alterado com sucesso!");
        }
    }
}
