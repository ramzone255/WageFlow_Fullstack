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
    public class Salary_PaymentConfiguration 
        : IEntityTypeConfiguration<Salary_Payment>
    {
        public void Configure(EntityTypeBuilder<Salary_Payment> builder)
        {
            builder.HasKey(ent => ent.id_salary_payment);
            builder.HasIndex(ent => ent.id_salary_payment).IsUnique();
            builder.Property(ent => ent.amount_salary_payment).HasMaxLength(20);
            builder.Property(ent => ent.date_salary_payment);
            builder.HasOne(ent => ent.Staff)
                .WithMany(ent => ent.Salary_Payment)
                .HasForeignKey(ent => ent.id_staff)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
