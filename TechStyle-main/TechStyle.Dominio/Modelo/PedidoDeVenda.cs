using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.Dominio.Modelo
{
    public class PedidoDeVenda
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public decimal SubTotal()
        {
            decimal valor = Produto.ValorVenda * Quantidade;
            return valor;
        }
    }
}
