namespace TechStyle.Dominio.Modelo
{
    public class PedidoDeVenda : IEntity
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
        public int IdVendas { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

        public decimal SubTotal()
        {
            decimal valor = Produto.ValorVenda * Quantidade;
            return valor;
        }
    }
}
