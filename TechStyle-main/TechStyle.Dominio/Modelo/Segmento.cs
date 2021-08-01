using System.Collections.Generic;

namespace TechStyle.Dominio.Modelo
{
    public class Segmento : IEntity
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public bool Ativo { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
