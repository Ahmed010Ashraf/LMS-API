using Domain.Entities.CourseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Data.Configurations
{
    public class LevelConfigurations : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode();

            builder.Property(x => x.Description)
                .HasMaxLength(1000)
                .IsUnicode();

            builder.Property(x => x.PicUrl)
                .HasMaxLength(500);

            builder.HasMany(x => x.Courses)
                .WithOne(x => x.Level)
                .HasForeignKey(x => x.LevelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
