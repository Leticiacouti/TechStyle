using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.DTO
{
    public class ProdutoDTO
    {
        public decimal ValorVenda { get; set; }
        public string Nome { get; set; }
        public string SKU { get; set; }
        public int IdSegmento { get; set; }
        public string Material { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tamanho { get; set; }
    }
}
