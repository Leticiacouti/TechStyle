using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.Dominio.Modelo
{
    public class PedidoDeVenda // ItemVenda
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
        public int IdVendas { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

        public decimal SubTotal()
        {
            decimal valor = Produto.ValorVenda * Quantidade;
            return valor;
        }
    }
}
