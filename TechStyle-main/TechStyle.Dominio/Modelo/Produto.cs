using System.Collections.Generic;

namespace TechStyle.Dominio.Modelo
{
    public class Produto : IEntity
    {
        public static int QuantidadeId { get; private set; }
        public int Id { get; set; }
        public decimal ValorVenda { get; private set; }
        public string Nome { get; private set; }
        public string SKU { get; private set; }
        public int IdSegmento { get; set; }
        public Segmento Segmento { get; private set; }
        public string Material { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tamanho { get; set; }
        public List<PedidoDeVenda> PedidoDeVenda { get; set; }
        public Estoque Estoque { get; set; }
        public Loja Loja { get; set; }
        public bool Ativo { get; private set; }

        public void Cadastrar(string nome, string material, string cor, string tamanho, string modelo, string marca,
                              int idSegmento, string sku, decimal valorVenda)
        {
            ValorVenda = valorVenda;
            Nome = nome;
            SKU = sku;
            Material = material;
            Cor = cor;
            Marca = marca;
            Modelo = modelo;
            Tamanho = tamanho;
            IdSegmento = idSegmento;
            Ativo = false;
        }

        public void AlterarItemProduto(string nome, string material, string cor, string tamanho,
                              string modelo, string marca, Segmento segmento, string sku, decimal valorVenda)
        {
            Nome = string.IsNullOrEmpty(nome.Trim()) ? Nome : nome;
            Material = string.IsNullOrEmpty(material.Trim()) ? Material : material;
            Cor = string.IsNullOrEmpty(cor.Trim()) ? Cor : cor;
            Tamanho = string.IsNullOrEmpty(tamanho.Trim()) ? Tamanho : tamanho;
            Modelo = string.IsNullOrEmpty(modelo.Trim()) ? Modelo : modelo;
            Marca = string.IsNullOrEmpty(marca.Trim()) ? Marca : marca;
            Segmento = segmento;
            SKU = string.IsNullOrEmpty(sku.Trim()) ? SKU : sku;
            ValorVenda = (valorVenda <= 0) ? ValorVenda : valorVenda;
        }

        // TODO: Incluir alterar status

        public void AlterarValorVenda(decimal valor)
        {
            ValorVenda = valor <= 0 ? ValorVenda : valor;
        }

        public override string ToString()
        {
            return Id + " - " + Nome + ", " + ValorVenda.ToString("F2");
        }
    }
}