using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Map
{
    public class SegmentoMap : IEntityTypeConfiguration<Segmento>
    {
        public void Configure(EntityTypeBuilder<Segmento> builder)
        {
            builder.ToTable("Segmento"); //Aqui damos nome para a tabela

            builder.HasKey(x => x.Id); //Determinar chave primaria
            
            builder.Property(x => x.Categoria)
                .HasColumnType("varchar(100)")
                .IsRequired(); 

            builder.Property(x => x.SubCategoria)
                .HasColumnType("varchar(100)")
                .IsRequired();
            // throw new NotImplementedException(); -> apagar
        }
    }
}
