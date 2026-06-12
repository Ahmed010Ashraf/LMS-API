using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CourseEntities
{
    public class StudentCertificate : BaseEntity
    {
        public Guid StudentId { get; set; }

        public Guid CourseId { get; set; }

        public Guid CertificateId { get; set; }

        public string CertificateNumber { get; set; } = null!;

        public string VerificationCode { get; set; } = null!;

        public ApplicationUser Student { get; set; } = null!;

        public Course Course { get; set; } = null!;

        public Certificate Certificate { get; set; } = null!;
    }
}
