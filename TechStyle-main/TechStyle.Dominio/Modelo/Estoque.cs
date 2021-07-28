namespace TechStyle.Dominio.Modelo
{
    public class Estoque : IEntity
    {
        public int Id { get; set; }
        public int QuantidadeMinima { get; set; }
        public string Local { get; set; }
        public int QuantidadeLocal { get; set; }
        public int QuantidadeTotal { get; set; }
        public Produto Produto { get; set; }
        public int IdProduto { get; set; }

        public void Cadastrar(int idProduto, int qtdMin, string local)
        {
            IdProduto = idProduto;
            QuantidadeMinima = qtdMin;
            Local = local;
        }

        public void AlterarLocal(string local)
        {
            Local = string.IsNullOrEmpty(local.Trim().ToUpper()) ? Local : local;
        }

        public void AlterarQuantidadeMinima(int qtd)
        {
            QuantidadeMinima = (qtd <= 0) ? QuantidadeMinima : qtd;
        }

        // TODO: adicionar no estoque

        public override string ToString()
        {
            return Produto + " - " + "Quantidade no estoque: " + QuantidadeLocal + "Localizado em: " + Local;
        }
    }
}
