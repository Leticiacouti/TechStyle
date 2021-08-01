using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Map
{
    class EstoqueMap : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("Estoque");

            builder.HasKey(x => x.Id);

            builder.HasOne<Produto>(o => o.Produto)
                   .WithOne(r => r.Estoque)
                   .HasForeignKey<Estoque>(f => f.IdProduto);
        }
    }
}
