using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TechStyle.Dados.Map;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<ItemDeVenda> ItemVenda { get; set; }
        public DbSet<Vendas> Venda { get; set; }
        public DbSet<Segmento> Segmento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
