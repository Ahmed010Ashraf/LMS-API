using Domain.Entities.ExamEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configurations
{
    public class StudentExamConfigurations : IEntityTypeConfiguration<StudentExam>
    {
        public void Configure(EntityTypeBuilder<StudentExam> builder)
        {
            builder.Property(x => x.Grade)
                .HasPrecision(5, 2);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.StudentExams)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Exam)
                .WithMany(x => x.StudentExams)
                .HasForeignKey(x => x.ExamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Answers)
                .WithOne(x => x.StudentExam)
                .HasForeignKey(x => x.StudentExamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
