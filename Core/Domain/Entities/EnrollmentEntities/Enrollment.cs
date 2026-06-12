using Domain.Entities.CourseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.EnrollmentEntities
{
    public class Enrollment : BaseEntity
    {
        public Guid StudentId { get; set; }

        public Guid CourseId { get; set; }

        public Guid EnrollmentCodeId { get; set; }

        public DateTime EndDate { get; set; }

        public ApplicationUser Student { get; set; } = null!;

        public Course Course { get; set; } = null!;

        public EnrollmentCode EnrollmentCode { get; set; } = null!;
    }
}
