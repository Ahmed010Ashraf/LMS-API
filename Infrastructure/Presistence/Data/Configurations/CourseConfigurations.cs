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
    public class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
          

           

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode();

            builder.Property(x => x.Description)
                .HasMaxLength(5000)
                .IsUnicode();

            builder.Property(x => x.PicUrl)
                .HasMaxLength(500);

            builder.HasOne(x => x.Level)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.LevelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
