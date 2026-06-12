using Domain.Entities.CourseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configurations
{
    public class StudentCourseProgressConfigurations : IEntityTypeConfiguration<StudentCourseProgress>
    {
        public void Configure(EntityTypeBuilder<StudentCourseProgress> builder)
        {
            builder.Property(x => x.CompletedPercentage)
                .HasPrecision(5, 2);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.CourseProgresses)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Course)
                .WithMany()
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
