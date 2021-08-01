using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.DTO;
using TechStyle.Dominio.Interface.Repositorios;
using TechStyle.Dominio.Interface.Services;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Services
{
    public class SegmentoService : ISegmentoService
    {
        private readonly IBibliotecaRepositorio _bibliotecaRepositorio;

        public SegmentoService(IBibliotecaRepositorio bibliotecaRepositorio)
        {
            _bibliotecaRepositorio = bibliotecaRepositorio;
        }

        public bool Cadastrar(SegmentoDTO dto)
        {
            bool segmentoValidacao = _bibliotecaRepositorio.SegmentoRepositorio.ExisteAlteracao(dto.Categoria, dto.SubCategoria);
            if (segmentoValidacao == true)
            {
                return false;
            }
            else
            {
                Segmento segmento = new Segmento();
                segmento.Categoria = dto.Categoria;
                segmento.SubCategoria = dto.SubCategoria;
                segmento.Ativo = true;
                _bibliotecaRepositorio.SegmentoRepositorio.Incluir(segmento);
                return true;
            }
        }

        public void Alterar(int id, SegmentoDTO dto)
        {
            Segmento segmento = _bibliotecaRepositorio.SegmentoRepositorio.SelecionarPorId(id);
            segmento.Categoria = string.IsNullOrEmpty(dto.Categoria.Trim()) ? segmento.Categoria : dto.Categoria;
            segmento.SubCategoria = string.IsNullOrEmpty(dto.SubCategoria.Trim()) ? segmento.SubCategoria : dto.SubCategoria;
            _bibliotecaRepositorio.SegmentoRepositorio.Alterar(segmento);
        }

        public void AlterarStatus(int id)
        {
            Segmento segmento = _bibliotecaRepositorio.SegmentoRepositorio.SelecionarPorId(id);
            segmento.Ativo = !segmento.Ativo;
            _bibliotecaRepositorio.SegmentoRepositorio.Alterar(segmento);
        }

        public List<Segmento> SelecionarTudo()
        {
            return _bibliotecaRepositorio.SegmentoRepositorio.SelecionarTudo();
        }

        public Segmento SelecionarPorId(int id)
        {
            return _bibliotecaRepositorio.SegmentoRepositorio.SelecionarPorId(id);
        }
    }
}
