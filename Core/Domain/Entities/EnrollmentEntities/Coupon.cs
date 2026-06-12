using Domain.Entities.CourseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.EnrollmentEntities
{
    public class Coupon : BaseEntity
    {
        public Guid CourseId { get; set; }

        public bool IsActive { get; set; }

        public DateTime ExpireAt { get; set; }

        public DateTime StartDate { get; set; }

        public int CurrentUsageCount { get; set; }

        public int UsageLimit { get; set; }

        public decimal Percentage { get; set; }

        public Course Course { get; set; } = null!;

        public ICollection<CouponUsage> CouponUsages { get; set; }
            = new HashSet<CouponUsage>();
    }
}
