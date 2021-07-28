namespace TechStyle.Dominio.Modelo
{
    public class ItemDeVenda : IEntity
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public Vendas Vendas { get; set; }
        public int IdVendas { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

        public void Cadastrar(int quantidade, int idProduto, int idVenda)
        {
            Quantidade = quantidade;
            IdProduto = idProduto;
            IdVendas = idVenda;
        }

        public override string ToString()
        {
            return Id + "RD" + Quantidade;
        }
    }
}
