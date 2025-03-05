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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(ent => ent.id_user);
            builder.HasIndex(ent => ent.id_user).IsUnique();
            builder.Property(ent => ent.user_name).HasMaxLength(30);
            builder.Property(ent => ent.user_password).HasMaxLength(30);
            builder.HasOne(ent => ent.Staff)
                .WithMany(ent => ent.User)
                .HasForeignKey(ent => ent.id_staff)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
