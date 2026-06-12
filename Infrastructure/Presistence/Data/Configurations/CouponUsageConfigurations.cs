using Domain.Entities.EnrollmentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configurations
{
    public class CouponUsageConfigurations : IEntityTypeConfiguration<CouponUsage>
    {
        public void Configure(EntityTypeBuilder<CouponUsage> builder)
        {
            builder.Property(x => x.DiscountAmount)
                .HasPrecision(10, 2);

            builder.HasOne(x => x.Coupon)
                .WithMany(x => x.CouponUsages)
                .HasForeignKey(x => x.CouponId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Student)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
