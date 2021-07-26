using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto"); 

            builder.HasKey(x => x.Id); 

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.SKU)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Material)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Cor)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Marca)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Modelo)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Tamanho)
                .HasColumnType("varchar(5)")
                .IsRequired();

            builder.Property(x => x.ValorVenda)
                .HasColumnType("decimal(10,2)") 
                .IsRequired();

            builder.HasMany<PedidoDeVenda>(p => p.PedidoDeVenda)
                .WithOne(s => s.Produto)
                .HasForeignKey(i => i.IdProduto);
        }
    }
}
