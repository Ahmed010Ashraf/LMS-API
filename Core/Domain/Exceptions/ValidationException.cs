using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ValidationException:Exception
    {
         public IEnumerable<string> _errors { get; set; }

        public ValidationException(IEnumerable<string> Errors) :base("Validation Errors")
        { 
        _errors = Errors;
        }
    }
}
