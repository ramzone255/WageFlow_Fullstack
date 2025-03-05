using Microsoft.EntityFrameworkCore;
using WageFlow.Domain.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WageFlow.Persistence.src.EntityTypeConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(ent => ent.id_post);
            builder.HasIndex(ent => ent.id_post).IsUnique();
            builder.Property(note => note.name_post).HasMaxLength(50);
        }
    }
}
