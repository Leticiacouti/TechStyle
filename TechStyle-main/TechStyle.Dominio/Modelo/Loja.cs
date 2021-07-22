using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.Dominio.Modelo
{
    public class Loja
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int QuantidadeLocal { get; set; }
        public int QuantidadeMinima { get; set; }
    }
}
