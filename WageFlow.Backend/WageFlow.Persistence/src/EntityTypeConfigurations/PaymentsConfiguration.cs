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
    public class PaymentsConfiguration : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> builder)
        {
            builder.HasKey(ent => ent.id_payments);
            builder.HasIndex(ent => ent.id_payments).IsUnique();
            builder.Property(ent => ent.amount_payments).HasMaxLength(20);
            builder.Property(ent => ent.comment).HasMaxLength(50);
            builder.Property(ent => ent.date_payments);
            builder.HasOne(ent => ent.Staff)
                .WithMany(ent => ent.Payments)
                .HasForeignKey(ent => ent.id_staff)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            builder.HasOne(ent => ent.Payments_Type)
                .WithMany(ent => ent.Payments)
                .HasForeignKey(ent => ent.id_payments_type)
                .IsRequired();
        }
    }
}
