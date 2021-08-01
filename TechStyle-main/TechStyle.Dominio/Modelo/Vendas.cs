using System;
using System.Collections.Generic;

namespace TechStyle.Dominio.Modelo
{
    public class Vendas : IEntity
    {
        public int Id { get; set; }
        public double ValorTotal { get; set; }
        public List<ItemDeVenda> ItemDeVenda { get; set; } = new();
        public bool Realizada { get; set; }
    }
}