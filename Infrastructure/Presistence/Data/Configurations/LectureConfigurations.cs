using Domain.Entities.CourseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configurations
{
    public class LectureConfigurations : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
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

            builder.Property(x => x.VideoUrl)
                .HasMaxLength(1000);

            builder.Property(x => x.DocumentUrl)
                .HasMaxLength(1000);

            builder.HasOne(x => x.Module)
                .WithMany(x => x.Lectures)
                .HasForeignKey(x => x.ModuleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Exams)
                .WithOne(x => x.Lecture)
                .HasForeignKey(x => x.LectureId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Progresses)
                .WithOne(x => x.Lecture)
                .HasForeignKey(x => x.LectureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
