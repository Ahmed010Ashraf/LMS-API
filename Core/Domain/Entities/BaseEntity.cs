using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity
    {
       
            public Guid Id { get; set; } = Guid.NewGuid();

            public DateTime CreatedAt { get; set; }

            public Guid? CreatedBy { get; set; }

            public DateTime? UpdatedAt { get; set; }

            public Guid? UpdatedBy { get; set; }
        
    }
}
