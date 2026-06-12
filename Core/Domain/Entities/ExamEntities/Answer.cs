using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ExamEntities
{
    public class Answer : BaseEntity
    {
        public string Text { get; set; } = null!;

        public bool IsCorrect { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; } = null!;
    }
}
