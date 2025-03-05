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
    public class Work_EntryConfiguration : IEntityTypeConfiguration<Work_Entry>
    {
        public void Configure(EntityTypeBuilder<Work_Entry> builder)
        {
            builder.HasKey(ent => ent.id_work_entry);
            builder.HasIndex(ent => ent.id_work_entry).IsUnique();
            builder.Property(ent => ent.quantity_work_entry).HasMaxLength(20);
            builder.Property(ent => ent.date_work_entry);
            builder.Property(ent => ent.amount_work_entry)
           .HasComputedColumnSql("[quantity_work_entry] * [amount_work_type]");
            builder.HasOne(ent => ent.Staff)
                .WithMany(ent => ent.Work_Entry)
                .HasForeignKey(ent => ent.id_staff)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            builder.HasOne(ent => ent.Work_Type)
                .WithMany(ent => ent.Work_Entry)
                .HasForeignKey(ent => ent.id_work_type)
                .IsRequired();
        }
    }
}
