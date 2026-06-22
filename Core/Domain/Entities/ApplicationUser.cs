using Domain.Entities.CourseEntities;
using Domain.Entities.EnrollmentEntities;
using Domain.Entities.ExamEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  

    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = null!;

        public int Age { get; set; }

        public string Gender { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string City { get; set; } = null!;

        public Guid? LevelId { get; set; } 

        public Level Level { get; set; } = null!;

        public ICollection<Enrollment> Enrollments { get; set; }
            = new HashSet<Enrollment>();

        public ICollection<StudentExam> StudentExams { get; set; }
            = new HashSet<StudentExam>();

        public ICollection<StudentAnswer> StudentAnswers { get; set; }
            = new HashSet<StudentAnswer>();

        public ICollection<StudentLessonProgress> LessonProgresses { get; set; }
            = new HashSet<StudentLessonProgress>();

        public ICollection<StudentCourseProgress> CourseProgresses { get; set; }
            = new HashSet<StudentCourseProgress>();

        public ICollection<StudentCertificate> Certificates { get; set; }
            = new HashSet<StudentCertificate>();
    }
}
