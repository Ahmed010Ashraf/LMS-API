using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ExamEntities
{
    public class StudentAnswer : BaseEntity
    {
        public Guid StudentExamId { get; set; }

        public Guid QuestionId { get; set; }

        public Guid AnswerId { get; set; }

        public StudentExam StudentExam { get; set; } = null!;

        public Question Question { get; set; } = null!;

        public Answer Answer { get; set; } = null!;
    }
}
