using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Map
{
    class ItemDeVendaMap : IEntityTypeConfiguration<ItemDeVenda>
    {
        public void Configure(EntityTypeBuilder<ItemDeVenda> builder)
        {
            builder.ToTable("Item de Venda");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantidade)
                   .HasColumnType("int")
                   .IsRequired();

            builder.HasOne<Produto>(p => p.Produto)
                   .WithMany(x => x.ItemDeVenda)
                   .HasForeignKey(u => u.IdProduto);
        }
    }
}
