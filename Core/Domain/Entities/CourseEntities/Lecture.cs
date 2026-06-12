using Domain.Entities.ExamEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CourseEntities
{
    public class Lecture : BaseEntity
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? PicUrl { get; set; }

        public string? VideoUrl { get; set; }

        public string? DocumentUrl { get; set; }

        public Guid ModuleId { get; set; }

        public Module Module { get; set; } = null!;

        public ICollection<Exam> Exams { get; set; }
            = new HashSet<Exam>();

        public ICollection<StudentLessonProgress> Progresses { get; set; }
            = new HashSet<StudentLessonProgress>();
    }
}
