using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Domain.src.Entities;

namespace WageFlow.Persistence.src.EntityTypeConfigurations
{
    public class Payments_TypeConfiguration 
        : IEntityTypeConfiguration<Payments_Type>
    {
        public void Configure(EntityTypeBuilder<Payments_Type> builder)
        {
            builder.HasKey(ent => ent.id_payments_type);
            builder.HasIndex(ent => ent.id_payments_type).IsUnique();
            builder.Property(ent => ent.name_payments_type).HasMaxLength(20);
        }
    }
}
