using Domain.Entities.EnrollmentEntities;
using Domain.Entities.ExamEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CourseEntities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? PicUrl { get; set; }
        public int Price { get; set; }

        public Guid LevelId { get; set; }

        public Level Level { get; set; } = null!;

        public ICollection<Module> Modules { get; set; }
            = new HashSet<Module>();

        public ICollection<Enrollment> Enrollments { get; set; }
            = new HashSet<Enrollment>();

        public ICollection<Certificate> Certificates { get; set; }
            = new HashSet<Certificate>();

        public ICollection<EnrollmentCode> EnrollmentCodes { get; set; }
            = new HashSet<EnrollmentCode>();

        public ICollection<Coupon> Coupons { get; set; }
            = new HashSet<Coupon>();


        public ICollection<Exam> Exams { get; set; }
         = new HashSet<Exam>();
    }
}
