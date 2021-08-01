using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Interface.Repositorios;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class VendasRepositorio : BaseRepositorio<Vendas>, IVendasRepositorio
    {
        public VendasRepositorio(Contexto contexto) : base(contexto)
        {

        }

        public override bool Incluir(Vendas vendas)
        {
            return base.Incluir(vendas);
        }

        public override bool Alterar(Vendas vendas)
        {
            return base.Alterar(vendas);
        }

        public override List<Vendas> SelecionarTudo()
        {
            return base.SelecionarTudo();
        }

        public override Vendas SelecionarPorId(int id)
        {
            return contexto.Venda.Include(x => x.ItemDeVenda)
                                 .ThenInclude(p => p.Produto)
                                 .FirstOrDefault(i => i.Id == id); //todo inclui metodo para retornar os produtos
        }
    }
}
