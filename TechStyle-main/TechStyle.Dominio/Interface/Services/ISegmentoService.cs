using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.DTO;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Interface.Services
{
    public interface ISegmentoService
    {
        bool Cadastrar(SegmentoDTO dto);
        void Alterar(int id, SegmentoDTO dto);
        void AlterarStatus(int id);
        List<Segmento> SelecionarTudo();
        Segmento SelecionarPorId(int id);
    }
}
