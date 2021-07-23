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
    class LojaMap : IEntityTypeConfiguration<Loja>
    {
        public void Configure(EntityTypeBuilder<Loja> builder)
        {
            builder.ToTable("Segmento"); //Aqui damos nome para a tabela

            builder.HasKey(x => x.Id); //Determinar chave primaria

            builder.Property(x => x.QuantidadeLocal)
                .HasColumnType("int(5)")
                .IsRequired();

            builder.Property(x => x.QuantidadeMinima)
                .HasColumnType("int(5)")
                .IsRequired();

            
        }
    }
}
