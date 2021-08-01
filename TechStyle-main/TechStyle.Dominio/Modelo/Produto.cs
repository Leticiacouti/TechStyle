using System.Collections.Generic;

namespace TechStyle.Dominio.Modelo
{
    public class Produto : IEntity
    {
        public int Id { get; set; }
        public double ValorVenda { get; set; }
        public string Nome { get; set; }
        public string SKU { get; set; }
        public int IdSegmento { get; set; }
        public Segmento Segmento { get; set; }
        public string Material { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tamanho { get; set; }
        public List<ItemDeVenda> ItemDeVenda { get; set; }
        public Estoque Estoque { get; set; }
        public bool Status { get; set; }
    }
}