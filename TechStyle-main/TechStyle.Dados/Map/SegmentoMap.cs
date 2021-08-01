using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Map
{
    public class SegmentoMap : IEntityTypeConfiguration<Segmento>
    {
        public void Configure(EntityTypeBuilder<Segmento> builder)
        {
            builder.ToTable("Segmento");

            builder.HasKey(x => x.Id);

            builder.HasMany<Produto>(p => p.Produtos)
                .WithOne(s => s.Segmento)
                .HasForeignKey(i => i.IdSegmento);
        }
    }
}
