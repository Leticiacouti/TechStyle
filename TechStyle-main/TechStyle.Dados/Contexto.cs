using Microsoft.EntityFrameworkCore;
using TechStyle.Dados.Map;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados
{
    public class Contexto : DbContext
    {
        public DbSet<Segmento> Segmento { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Loja> Loja { get; set; }
        public DbSet<Vendas> Vendas { get; set; }
        public DbSet<ItemDeVenda> ItemDeVenda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=; Database=TechStyle; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SegmentoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new EstoqueMap());
            modelBuilder.ApplyConfiguration(new LojaMap());
            modelBuilder.ApplyConfiguration(new VendasMap());
            modelBuilder.ApplyConfiguration(new ItemDeVendaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
