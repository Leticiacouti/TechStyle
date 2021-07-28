using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStyle.API.DTO;
using TechStyle.Dados.Repositorio;
using TechStyle.Dominio.Modelo;

namespace TechStyle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentoController : ControllerBase
    {
        private readonly SegmentoRepositorio _repo;

        public SegmentoController()
        {
            _repo = new SegmentoRepositorio();
        }

        [HttpGet]
        public IEnumerable<Segmento> Get()
        {
            return _repo.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Segmento GetById(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        [HttpPost]
        public void Post([FromBody] SegmentoDTO dto)
        {
            var segmento = new Segmento();
            segmento.Cadastrar(dto.Categoria, dto.SubCategoria);

            _repo.Incluir(segmento);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SegmentoDTO dto)
        {
            var segmento = new Segmento();
            segmento.Alterar(id, dto.Categoria, dto.SubCategoria);
            _repo.Alterar(segmento);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.AlterarStatus(id);
        }
    }
}
