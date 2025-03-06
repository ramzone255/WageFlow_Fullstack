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
    public class Work_Entry_Salary_PaymentConfiguration
        : IEntityTypeConfiguration<Work_Entry_Salary_Payment>
    {
        public void Configure(EntityTypeBuilder<Work_Entry_Salary_Payment> builder)
        {
            builder.HasKey(ent => ent.id_work_entry_salary_payment);
            builder.HasIndex(ent => ent.id_work_entry_salary_payment).IsUnique();
            //builder.Property(ent => ent.id_work_entry);
            //builder.Property(ent => ent.id_salary_payment);
            builder.HasOne(ent => ent.Work_Entry)
                .WithMany(ent => ent.Work_Entry_Salary_Payment)
                .HasForeignKey(ent => ent.id_work_entry)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
            builder.HasOne(ent => ent.Salary_Payment)
                .WithMany(ent => ent.Work_Entry_Salary_Payment)
                .HasForeignKey(ent => ent.id_salary_payment)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
