using System;
using System.Collections.Generic;

namespace TechStyle.Dominio.Modelo
{
    public class Segmento
    {
        public static int QuantidadeId { get; set; }
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public bool Ativo { get; set; }
        public List<Produto> Produtos { get; set; }


        public void Cadastrar(string categoria, string subcategoria)
        {
            Categoria = categoria;
            SubCategoria = subcategoria;
            Ativo = true;
        }

       public void Alterar(string categoria, string subCategoria)
        {
            Categoria = string.IsNullOrEmpty(categoria.Trim()) ? Categoria : categoria;
            SubCategoria = string.IsNullOrEmpty(subCategoria.Trim()) ? SubCategoria : subCategoria;
        }

        public void AlterarStatus(bool ativo)
        {
            Ativo = ativo;
        }

        public override string ToString()
        {
            return Id + ", " + Categoria + ", " + SubCategoria;
        }
    }
}
