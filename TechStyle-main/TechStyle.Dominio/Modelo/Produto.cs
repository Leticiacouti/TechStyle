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
        public DetalheProduto DetalheProduto { get; private set; }
        public bool Ativo { get; private set; }

        public Produto()
        {
            Segmento = new Segmento();
            DetalheProduto = new DetalheProduto();
        }

        public void Cadastrar(decimal valorVenda, string nome, string sku, Segmento segmento, DetalheProduto detalheProduto)
        {
            Id = QuantidadeId + 1;
            QuantidadeId++;
            ValorVenda = valorVenda;
            Nome = nome;
            Segmento = segmento;
            DetalheProduto = detalheProduto;
            SKU = sku;
            Ativo = false;

            // ValidarDuplicidade

            // chamar insercao no banco
            // ID, CATEGORIA,    SUB       = A SOMA DE TUDO É O SEGMENTO
            /* 1, moda feminina, praia */
            /* 2, moda feminina, casual */
            /* 3, moda feminina, social */
            /* 4, moda feminina, fitness */
            /* 5, moda feminina, lingerie */
        }

        public void AlterarItemProduto(decimal valorVenda, string nome, string sku, int idSegmento, DetalheProduto detalheProduto)
        {
            ValorVenda = (valorVenda == 0) ? ValorVenda : valorVenda;
            Nome = string.IsNullOrEmpty(nome.Trim()) ? Nome : nome;
            SKU = string.IsNullOrEmpty(sku.Trim()) ? SKU : sku;
            
        }

        public override string ToString()
        {
            return Nome + ", " + ValorVenda + ", " + SKU + ", " + DetalheProduto + ", " + Segmento;
        }



    }
}
