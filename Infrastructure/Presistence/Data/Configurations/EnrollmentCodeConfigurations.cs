using Domain.Entities.EnrollmentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configurations
{
    public class EnrollmentCodeConfigurations : IEntityTypeConfiguration<EnrollmentCode>
    {
        public void Configure(EntityTypeBuilder<EnrollmentCode> builder)
        {
            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(x => x.CreatedByName)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode();

            builder.HasOne(x => x.Course)
                .WithMany(x => x.EnrollmentCodes)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Enrollments)
                .WithOne(x => x.EnrollmentCode)
                .HasForeignKey(x => x.EnrollmentCodeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
