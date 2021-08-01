using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.DTO
{
    public class EstoqueDTO
    {
        public int QuantidadeMin { get; set; }
        public string Local { get; set; }
        public int Quantidade { get; set; }
        public int IdProduto { get; set; }

    }
}
