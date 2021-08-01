using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Map
{
    class ItemDeVendaMap : IEntityTypeConfiguration<ItemDeVenda>
    {
        public void Configure(EntityTypeBuilder<ItemDeVenda> builder)
        {
            builder.ToTable("ItemVenda");

            builder.HasKey(x => new { x.IdProduto, x.IdVenda });

            builder.HasOne<Produto>(f => f.Produto)
                .WithMany(d => d.ItemDeVenda)
                .HasForeignKey(k => k.IdProduto);

            builder.HasOne<Vendas>(f => f.Vendas)
                .WithMany(d => d.ItemDeVenda)
                .HasForeignKey(k => k.IdVenda);
        }
    }
}
