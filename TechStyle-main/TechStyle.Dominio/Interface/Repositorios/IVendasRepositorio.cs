using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Interface.Repositorios
{
    public interface IVendasRepositorio
    {
        bool Incluir(Vendas vendas);
        bool Alterar(Vendas vendas);
        Vendas SelecionarPorId(int id);
        List<Vendas> SelecionarTudo();
    }
}
