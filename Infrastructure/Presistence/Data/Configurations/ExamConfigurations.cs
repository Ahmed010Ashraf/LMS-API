using Domain.Entities.ExamEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configurations
{
    public class ExamConfigurations : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode();

            builder.HasOne(x => x.Lecture)
                .WithMany(x => x.Exams)
                .HasForeignKey(x => x.LectureId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(e => e.Course).WithMany(x => x.Exams)
                .HasForeignKey(e => e.CourseId);

            builder.HasMany(x => x.Questions)
                .WithOne(x => x.Exam)
                .HasForeignKey(x => x.ExamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.StudentExams)
                .WithOne(x => x.Exam)
                .HasForeignKey(x => x.ExamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
