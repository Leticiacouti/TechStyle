using TechStyle.Dominio.Repositorio;
    using System;

namespace TechStyle.Dominio.Modelo
{
    public class Produto
    {
        public static int QuantidadeId { get; private set; }
        public int Id { get; private set; }
        public decimal ValorVenda { get; private set; }
        public string Nome { get; private set; }
        public string SKU { get; private set; }
        public Segmento Segmento { get; private set; }
        public string Material { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tamanho { get; set; }
        public bool Ativo { get; private set; }

        public Produto()
        {
            Segmento = new Segmento();
            //DetalheProduto = new DetalheProduto();
        }

        public void Cadastrar(string nome, string material, string cor, string tamanho, string modelo, string marca,
                              Segmento segmento, string sku, decimal valorVenda)
        {
            // Criar lista de Ids 

            if (segmento != null)
            {
                Segmento = segmento;
                Id = QuantidadeId + 1;
                QuantidadeId++;
                ValorVenda = valorVenda;
                Nome = nome;
                SKU = sku;
                Material = material;
                Cor = cor;
                Marca = marca;
                Modelo = modelo;
                Tamanho = tamanho;
                Ativo = false;
            }
            // ValidarDuplicidade

            // chamar insercao no banco
            // ID, CATEGORIA,    SUB       = A SOMA DE TUDO É O SEGMENTO
            /* 1, moda feminina, praia */
            /* 2, moda feminina, casual */
            /* 3, moda feminina, social */
            /* 4, moda feminina, fitness */
            /* 5, moda feminina, lingerie */
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

        // Incluir alterar status

        public void AlterarValorVenda(decimal valor)
        {
            ValorVenda = valor <= 0 ? ValorVenda : valor;
        }

        public override string ToString()
        {
            return Id + " - " + Nome + ", " + ValorVenda;
        }
    }
}