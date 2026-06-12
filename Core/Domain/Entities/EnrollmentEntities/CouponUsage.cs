using Domain.Entities.CourseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.EnrollmentEntities
{
    public class CouponUsage : BaseEntity
    {
        public Guid CouponId { get; set; }

        public Guid UserId { get; set; }

        public Guid CourseId { get; set; }

        public decimal DiscountAmount { get; set; }

        public Coupon Coupon { get; set; } = null!;

        public ApplicationUser Student { get; set; } = null!;

    }
}
