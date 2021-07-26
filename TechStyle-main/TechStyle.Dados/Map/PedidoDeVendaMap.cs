using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Map
{
    class PedidoDeVendaMap : IEntityTypeConfiguration<PedidoDeVenda>
    {
        public void Configure(EntityTypeBuilder<PedidoDeVenda> builder)
        {
            builder.ToTable("Pedido de vendas");
            builder.HasKey(x => new { x.Id, x.IdVenda });

            builder.Property(x => x.Quantidade)
                   .HasColumnType("int")
                   .IsRequired();

            builder.HasOne<Produto>(p => p.Produto)
                   .WithMany(x => x.PedidoDeVenda)
                   .HasForeignKey(i => i.IdProduto);
        }
    }
}
