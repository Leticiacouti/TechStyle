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
    class PedidoDeVendaMap : IEntityTypeConfiguration<PedidoDeVenda>
    {
        public void Configure(EntityTypeBuilder<PedidoDeVenda> builder)
        {
            builder.ToTable("Pedido de vendas");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantidade).HasColumnType("int").IsRequired();
        }
    }
}
