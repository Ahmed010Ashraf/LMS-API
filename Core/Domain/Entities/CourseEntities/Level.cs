using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CourseEntities
{
    public class Level : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string? PicUrl { get; set; }

        public string? Description { get; set; }

        public ICollection<Course> Courses { get; set; }
            = new HashSet<Course>();

        public ICollection<ApplicationUser> Students { get; set; }
            = new HashSet<ApplicationUser>();
    }
}
