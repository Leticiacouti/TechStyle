namespace TechStyle.Dominio.Modelo
{
    public class Loja : IEntity
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int IdProduto { get; set; }
        public int QuantidadeLocal { get; set; }
        public int QuantidadeMinima { get; set; }

        public void Cadastrar(Produto produto, int qtdMin)
        {
            Id = produto.Id;
            Produto = produto;
            QuantidadeLocal = 0;
            QuantidadeMinima = qtdMin;
        }

        public bool AdicionarNaLoja(int qtd, Estoque estoque)
        {
            if (estoque.Id == Id)
            {
                QuantidadeLocal += qtd;
                estoque.QuantidadeLocal -= qtd;
                return true;
            }
            else
                return false;
        }
    }
}
