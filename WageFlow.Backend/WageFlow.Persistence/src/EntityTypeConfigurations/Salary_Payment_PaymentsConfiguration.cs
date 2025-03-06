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
    public class Salary_Payment_PaymentsConfiguration 
        : IEntityTypeConfiguration<Salary_Payment_Payments>
    {
        public void Configure(EntityTypeBuilder<Salary_Payment_Payments> builder)
        {
            builder.HasKey(ent => ent.id_salary_payment_payments);
            builder.HasIndex(ent => ent.id_salary_payment_payments).IsUnique();
            //builder.Property(ent => ent.id_payments);
            //builder.Property(ent => ent.id_salary_payment);
            builder.HasOne(ent => ent.Payments)
                .WithMany(ent => ent.Salary_Payment_Payments)
                .HasForeignKey(ent => ent.id_payments)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
            builder.HasOne(ent => ent.Salary_Payment)
                .WithMany(ent => ent.Salary_Payment_Payments)
                .HasForeignKey(ent => ent.id_salary_payment)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
