using System.Collections.Generic;

namespace TechStyle.Dominio.Modelo
{
    public class Vendas : IEntity
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public List<ItemDeVenda> ItemDeVenda { get; set; } = new();

        public void CadastrarVenda(List<ItemDeVenda> item)
        {
            Vendas v = new Vendas();
        }

        public void AddPedidoVenda(ItemDeVenda itemDeVenda)
        {
            ItemDeVenda.Add(itemDeVenda);
        }

        public void RemovePedidoVenda(ItemDeVenda itemDeVenda)
        {
            ItemDeVenda.Remove(itemDeVenda);
        }
        public void TotalPedido()
        {
            foreach (ItemDeVenda pedido in ItemDeVenda)
            {
                ValorTotal += pedido.Quantidade * pedido.Produto.ValorVenda;
            }
        }
    }
}

// definir dados como inicializaçao
// add-migration atualizacaodetabelas
// update database