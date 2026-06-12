using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CourseEntities
{
    public class Module : BaseEntity
    {
        public string Title { get; set; } = null!;

        public Guid CourseId { get; set; }

        public Course Course { get; set; } = null!;

        public ICollection<Lecture> Lectures { get; set; }
            = new HashSet<Lecture>();
    }
}
