namespace TechStyle.Dominio.Modelo
{
    public class ItemDeVenda : IEntity
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public Vendas Vendas { get; set; }
        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public double Quantidade { get; set; }
    }
}
