using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CourseEntities
{
    public class StudentCourseProgress : BaseEntity
    {
        public Guid StudentId { get; set; }

        public Guid CourseId { get; set; }

        public bool IsCompleted { get; set; }

        public int CompletedLessons { get; set; }

        public int TotalLessons { get; set; }

        public decimal CompletedPercentage { get; set; }

        public DateTime? CompletedAt { get; set; }

        public ApplicationUser Student { get; set; } = null!;

        public Course Course { get; set; } = null!;
    }
}
