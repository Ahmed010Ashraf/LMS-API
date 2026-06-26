using Microsoft.AspNetCore.Http;
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
        public int Price { get; set; }

        public IFormFile? PicUrl { get; set; }

        public Guid LevelId { get; set; }
    }
}
