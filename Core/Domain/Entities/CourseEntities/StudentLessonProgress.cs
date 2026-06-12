using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CourseEntities
{
    public class StudentLessonProgress : BaseEntity
    {
        public Guid StudentId { get; set; }

        public Guid LectureId { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompletedAt { get; set; }

        public ApplicationUser Student { get; set; } = null!;

        public Lecture Lecture { get; set; } = null!;
    }
}
