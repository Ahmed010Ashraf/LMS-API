using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class ValidationErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public IEnumerable<ValidationErrors> Errors { get; set; }
    }

    public class ValidationErrors
    {
        public string Key { get; set; }
        public IEnumerable<string> Value { get; set; }
    }
}
