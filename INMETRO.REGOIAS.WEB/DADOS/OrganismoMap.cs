using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INMETRO.REGOIAS.WEB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackExchange.Redis;

namespace INMETRO.REGOIAS.WEB.DADOS
{
    public class OrganismoMap : IEntityTypeConfiguration<Organismo>
    {

        public void Configure(EntityTypeBuilder<Organismo> builder)
        {
            builder.ToTable("TB_ORGANISMO");
            builder.HasKey(o => o.Id);
            builder.Property(t => t.CodigoOIA)
                .IsRequired()
                .HasColumnType("String")
                .HasColumnName("CDA_CODIGO_OIA");
           builder.Property(o => o.Nome)
                .HasColumnName("NOM_ORGANISMO")
                .IsRequired();
            builder.Property(o => o.EhAtivo)
                .HasColumnName("CDA_ATIVO")
                .IsRequired();
          

        }
       
    }
}
