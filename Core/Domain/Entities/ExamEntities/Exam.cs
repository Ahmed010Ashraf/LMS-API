using Domain.Entities.CourseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ExamEntities
{
    public class Exam : BaseEntity
    {
        public TimeSpan Duration { get; set; }

        public string Title { get; set; } = null!;

        public DateTime StartTime { get; set; }

        public bool IsAvailable { get; set; }

        public Guid LectureId { get; set; }

        public Lecture Lecture { get; set; } = null!;

        public ICollection<Question> Questions { get; set; }
            = new HashSet<Question>();

        public ICollection<StudentExam> StudentExams { get; set; }
            = new HashSet<StudentExam>();
    }
}
