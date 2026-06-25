using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class JwtOptions
    {
        public string Issure { get; set; }
        public string Audiance { get; set; }
        public string Key { get; set; }
        public double Expiration { get; set; }
    }
}
