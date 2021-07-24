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
    class VendasMap : IEntityTypeConfiguration<Venda>
    {
        
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Vendas"); 

            builder.HasKey(x => x.Id); 

            builder.Property(x => x.ValorTotal)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.HasMany<PedidoDeVenda>(p => p.PedidoDeVendas)
                .WithOne(x => x.Venda)
                .HasForeignKey(i => i.Id);
        }
    }
}
