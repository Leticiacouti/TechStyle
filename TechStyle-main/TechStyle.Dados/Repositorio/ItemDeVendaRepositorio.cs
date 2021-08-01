using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Interface.Repositorios;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class ItemDeVendaRepositorio : BaseRepositorio<ItemDeVenda>, IItemDeVendaRepositorio
    {
        public ItemDeVendaRepositorio(Contexto contexto) : base(contexto)
        {

        }
    }
}
