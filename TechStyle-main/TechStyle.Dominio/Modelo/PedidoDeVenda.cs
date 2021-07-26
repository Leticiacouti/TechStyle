namespace TechStyle.Dominio.Modelo
{
    public class PedidoDeVenda : IEntity
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

        public void Cadastrar(int quantidade, int idProduto, int idVenda)
        {
            Quantidade = quantidade;
            IdProduto = idProduto;
            IdVenda = idVenda;
        }

        public decimal SubTotal()
        {
            decimal valor = Produto.ValorVenda * Quantidade;
            return valor;
        }
    }
}
