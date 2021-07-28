using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class ItemDeVendasRepositorio : BaseRepositorio<ItemDeVenda>
    {
        public void Incluir(Produto produto, int quantidade, Vendas vendas)
        {
            ItemDeVenda pV = new();
            pV.Cadastrar(quantidade, produto.Id, vendas.Id);
            base.Incluir(pV);
        }

        public List<ItemDeVenda> SelecionarPorVenda(int idVenda)
        {
            return contexto.ItemDeVenda.Where(x => x.IdVendas == idVenda).ToList();
        }
    }
}
