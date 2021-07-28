using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Map
{
    class VendasMap : IEntityTypeConfiguration<Vendas>
    {
        
        public void Configure(EntityTypeBuilder<Vendas> builder)
        {
            builder.ToTable("Vendas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ValorTotal)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.HasMany<ItemDeVenda>(p => p.ItemDeVenda)
                .WithOne(x => x.Vendas)
                .HasForeignKey(i => i.IdVendas);
        }
    }
}
