using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ExamEntities
{
    public class Question : BaseEntity
    {
        public string Title { get; set; } = null!;

        public string? PicUrl { get; set; }

        public Guid ExamId { get; set; }

        public Exam Exam { get; set; } = null!;

        public ICollection<Answer> Answers { get; set; }
            = new HashSet<Answer>();
    }
}
