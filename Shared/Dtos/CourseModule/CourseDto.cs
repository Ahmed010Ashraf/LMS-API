using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.CourseModule
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? PicUrl { get; set; }

        public Guid LevelId { get; set; }

        public string LevelName { get; set; } = null!;

        public int NumberOfLectures { get; set; }
    }
}
