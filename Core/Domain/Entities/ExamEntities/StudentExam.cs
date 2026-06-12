using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ExamEntities
{
    public class StudentExam : BaseEntity
    {
        public Guid StudentId { get; set; }

        public Guid ExamId { get; set; }

        public decimal Grade { get; set; }

        public bool IsPassed { get; set; }

        public DateTime SubmittedAt { get; set; }

        public ApplicationUser Student { get; set; } = null!;

        public Exam Exam { get; set; } = null!;

        public ICollection<StudentAnswer> Answers { get; set; }
            = new HashSet<StudentAnswer>();
    }
}
