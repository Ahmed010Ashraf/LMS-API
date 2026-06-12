using Domain.Entities.CourseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configurations
{
    public class CertificateConfigurations : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode();

            builder.Property(x => x.PicUrl)
                .HasMaxLength(500);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Certificates)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.StudentCertificates)
                .WithOne(x => x.Certificate)
                .HasForeignKey(x => x.CertificateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
