using Domain.Entities.CourseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configurations
{
    public class StudentLessonProgressConfigurations : IEntityTypeConfiguration<StudentLessonProgress>
    {
        public void Configure(EntityTypeBuilder<StudentLessonProgress> builder)
        {
            builder.HasOne(x => x.Student)
                .WithMany(x => x.LessonProgresses)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Lecture)
                .WithMany(x => x.Progresses)
                .HasForeignKey(x => x.LectureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
