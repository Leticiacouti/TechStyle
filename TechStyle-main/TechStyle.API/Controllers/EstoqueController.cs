using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStyle.Dominio.DTO;
using TechStyle.Dominio.Interface.Services;
using TechStyle.Dominio.Modelo;
using TechStyle.Dominio.Repositorio;

namespace TechStyle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpGet]
        public List<Estoque> Get()
        {
            return _estoqueService.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Estoque Get(int id)
        {
            return _estoqueService.SelecionarPorId(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EstoqueDTO dto)
        {
            var result = _estoqueService.CadastrarProdutoNoEstoque(dto);
            if (result == true)
            {
                return Ok("Produto cadastrado");
            }
            else
            {
                return BadRequest("Produto já cadastrado");
            }
        }

        [HttpPut("{id}/AlterarLocal")]
        public IActionResult AlterarLocalProduto(int id, [FromQuery] EstoqueDTO dto)
        {
            _estoqueService.AlterarLocal(id, dto);
            return Ok("Localidade do produto alterada");
        }

        [HttpPut("{id}/AlterarQuantidadeMinima")]
        public IActionResult AlterarQuantidadeMinima(int id, [FromQuery] EstoqueDTO dto)
        {
            _estoqueService.AlterarQuantidadeMinima(id, dto);
            return Ok("Quantidade Minima em estoque alterada!");
        }
    }
}
