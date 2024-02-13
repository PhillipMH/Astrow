using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow.Shared.DTO
{
    public class StudentDTO
    {
        public Guid StudentId { get; set; }
        public string Unilogin { get; set; }
        public string Name { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public TimeSpan FlexTotal { get; set; }

    }
}
