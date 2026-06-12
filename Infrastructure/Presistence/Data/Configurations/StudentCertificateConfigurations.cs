using Domain.Entities.CourseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configurations
{
    public class StudentCertificateConfigurations : IEntityTypeConfiguration<StudentCertificate>
    {
        public void Configure(EntityTypeBuilder<StudentCertificate> builder)
        {
            builder.Property(x => x.CertificateNumber)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(x => x.VerificationCode)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Certificates)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Course)
                .WithMany()
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Certificate)
                .WithMany(x => x.StudentCertificates)
                .HasForeignKey(x => x.CertificateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
