using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStyle.Dominio.DTO;
using TechStyle.Dados.Repositorio;
using TechStyle.Dominio.Interface.Services;
using TechStyle.Dominio.Modelo;

namespace TechStyle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _produtoService.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            return _produtoService.SelecionarPorId(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoDTO dto)
        {
            var result = _produtoService.CadastrarProduto(dto);
            if (result == true)
            {
                return Ok("Produto cadastrado!");
            }
            else
            {
                return BadRequest("Ocorreu um erro ao cadastrar!");
            }
        }

        [HttpPut("{id}/AlterarDados")]
        public IActionResult PutAlterarDados(int id, [FromBody] ProdutoDTO dto)
        {
            _produtoService.Alterar(id, dto);
            return Ok("Produto alterado com sucesso!");
        }

        [HttpPut("{id}/AlterarStatus")]
        public IActionResult PutAlterarStatus(int id)
        {
            _produtoService.AlterarStatus(id);
            return Ok("Status do produto alterado com sucesso!");
        }
    }
}
