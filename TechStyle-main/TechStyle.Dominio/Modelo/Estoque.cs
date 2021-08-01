namespace TechStyle.Dominio.Modelo
{
    public class Estoque : IEntity
    {
        public int Id { get; set; }
        public double QuantidadeMin { get; set; }
        public string Local { get; set; }
        public double Quantidade { get; set; }
        public Produto Produto { get; set; }
        public int IdProduto { get; set; }
        public bool Status { get; set; }
    }
}
