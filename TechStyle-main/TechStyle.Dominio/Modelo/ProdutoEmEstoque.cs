namespace TechStyle.Dominio.Modelo
{
    public class ProdutoEmEstoque
    {
        public int Id { get; set; }
        public int QuantidadeMinima { get; set; }
        public string Local { get; set; }
        public int QuantidadeLocal { get; set; }
        public int QuantidadeTotal { get; set; }
        public Produto Produto { get; set; }

        public void Cadastrar(Produto produto, int qtdMin, string local)
        {
            if (produto != null)
            {
                Produto = produto;
                Id = produto.Id;
                QuantidadeMinima = qtdMin;
                Local = local;
            }
        }

    }  
}
