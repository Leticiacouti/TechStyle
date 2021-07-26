using System.Collections.Generic;

namespace TechStyle.Dominio.Modelo
{
    public class Venda : IEntity
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public List<PedidoDeVenda> PedidoDeVenda { get; set; } = new();
        
        public void AddPedidoVenda(PedidoDeVenda pedidoDeVenda)
        {
            PedidoDeVenda.Add(pedidoDeVenda);
        }

        public void RemovePedidoVenda(PedidoDeVenda pedidoDeVenda)
        {
            PedidoDeVenda.Remove(pedidoDeVenda);
        }

        public void TotalPedido()
        {
            foreach(PedidoDeVenda pedido in PedidoDeVenda)
            {
                ValorTotal += pedido.SubTotal();
            }
        }
    }
}

// definir dados como inicializaçao
// add-migration atualizacaodetabelas
// update database