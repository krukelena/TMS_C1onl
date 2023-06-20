using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_TMS_C1onl.Models
{
    public record Customer
    {
        public int Id { get; private set; }
        public string? Firstname { get; private set; }
        public string? Lastname { get; private set; }
        public string? Email { get; private set; }
        public int? Age { get; private set; }
    }
}
