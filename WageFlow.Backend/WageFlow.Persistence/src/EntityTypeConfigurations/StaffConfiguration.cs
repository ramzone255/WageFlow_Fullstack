using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Domain.src.Entities;

namespace WageFlow.Persistence.src.EntityTypeConfigurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(ent => ent.id_staff);
            builder.HasIndex(ent => ent.id_staff).IsUnique();
            builder.Property(ent => ent.lastname_staff).HasMaxLength(50);
            builder.Property(ent => ent.name_staff).HasMaxLength(50);
            builder.Property(ent => ent.patronymic_staff).HasMaxLength(50);
            builder.Property(ent => ent.email_staff).HasMaxLength(50);
            builder.HasOne(ent => ent.Post)
                .WithMany(ent => ent.Staff)
                .HasForeignKey(ent => ent.id_post)
                .IsRequired();
        }
    }
}
