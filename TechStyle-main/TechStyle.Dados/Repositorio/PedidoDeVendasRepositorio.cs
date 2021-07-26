using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class PedidoDeVendasRepositorio : BaseRepositorio<PedidoDeVenda>
    {
        public void Incluir(Produto produto, int quantidade, Venda venda)
        {
            PedidoDeVenda pV = new();
            pV.Cadastrar(quantidade, produto.Id, venda.Id);
            base.Incluir(pV);
        }

        public List<PedidoDeVenda> SelecionarPorVenda(int idVenda)
        {
            return contexto.PedidoDeVenda.Where(x => x.IdVenda == idVenda).ToList();
        }
    }
}
