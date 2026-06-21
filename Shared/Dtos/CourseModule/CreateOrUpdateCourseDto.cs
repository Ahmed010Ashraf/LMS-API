using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.CourseModule
{
    public class CreateOrUpdateCourseDto
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? PicUrl { get; set; }

        public Guid LevelId { get; set; }
    }
}
