using Domain.Entities.EnrollmentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configurations
{
    public class CouponConfigurations : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.Property(x => x.Percentage)
                .HasPrecision(5, 2);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Coupons)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.CouponUsages)
                .WithOne(x => x.Coupon)
                .HasForeignKey(x => x.CouponId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
