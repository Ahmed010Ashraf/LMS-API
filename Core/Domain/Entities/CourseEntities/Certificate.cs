using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CourseEntities
{
    public class Certificate : BaseEntity
    {
        public string Title { get; set; } = null!;

        public string? PicUrl { get; set; }

        public Guid CourseId { get; set; }

        public Course Course { get; set; } = null!;

        public ICollection<StudentCertificate> StudentCertificates { get; set; }
            = new HashSet<StudentCertificate>();
    }
}
