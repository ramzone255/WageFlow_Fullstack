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
    public class Work_TypeConfiguration 
        : IEntityTypeConfiguration<Work_Type>
    {
        public void Configure(EntityTypeBuilder<Work_Type> builder)
        {
            builder.HasKey(ent => ent.id_work_type);
            builder.HasIndex(ent => ent.id_work_type).IsUnique();
            builder.Property(ent => ent.name_work_type).HasMaxLength(50);
            builder.Property(ent => ent.amount_work_type).HasMaxLength(10);
        }
    }
}
