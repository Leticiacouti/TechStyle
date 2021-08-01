using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.DTO;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Interface.Services
{
    public interface IVendasService
    {
        bool RealizarVenda(List<ItemDeVendaDTO> dto);
        List<Vendas> SelecionarTudo();
        Vendas SelecionarPorId(int id);
    }
}
