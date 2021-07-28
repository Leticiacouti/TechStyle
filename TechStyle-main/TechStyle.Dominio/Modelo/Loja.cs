namespace TechStyle.Dominio.Modelo
{
    public class Loja : IEntity
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int IdProduto { get; set; }
        public int QuantidadeLocal { get; set; }
        public int QuantidadeMinima { get; set; }

        public void Cadastrar(int idProduto, int qtdMin)
        {
            IdProduto = idProduto;
            QuantidadeLocal = 0;
            QuantidadeMinima = qtdMin;
        }

        public bool AdicionarNaLoja(int qtd, Estoque estoque)
        {
            QuantidadeLocal += qtd;
            estoque.QuantidadeLocal -= qtd;
            return true;
        }
    }
}
