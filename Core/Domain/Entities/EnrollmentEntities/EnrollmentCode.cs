using Domain.Entities.CourseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.EnrollmentEntities
{
    public class EnrollmentCode : BaseEntity
    {
        public string Code { get; set; } = null!;

        public Guid CourseId { get; set; }

        public string CreatedByName { get; set; } = null!;

        public int UsageDuration { get; set; }

        public DateTime ExpireAt { get; set; }

        public bool IsActive { get; set; }

        public Course Course { get; set; } = null!;

        public ICollection<Enrollment> Enrollments { get; set; }
            = new HashSet<Enrollment>();
    }
}
