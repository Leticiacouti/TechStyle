using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.Dominio.Modelo
{
    public class Venda
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public List<PedidoDeVenda> PedidoDeVendas { get; set; } = new();

        public void AddPedidoVenda(PedidoDeVenda pedidoDeVenda)
        {
            PedidoDeVendas.Add(pedidoDeVenda);
        }

        public void RemovePedidoVenda(PedidoDeVenda pedidoDeVenda)
        {
            PedidoDeVendas.Remove(pedidoDeVenda);
        }

        public void TotalPedido()
        {
            foreach(PedidoDeVenda pedido in PedidoDeVendas)
            {
                ValorTotal += pedido.SubTotal();
            }
        }
    }
}
