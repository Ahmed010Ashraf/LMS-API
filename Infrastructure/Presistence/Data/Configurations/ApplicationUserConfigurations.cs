using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configurations
{
    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode();

            builder.Property(x => x.Gender)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

           

            builder.HasOne(x => x.Level)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.LevelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Enrollments)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.StudentExams)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.LessonProgresses)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.CourseProgresses)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Certificates)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
