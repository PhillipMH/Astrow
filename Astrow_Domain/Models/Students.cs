using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow_Domain.Models
{
    public class Students
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public TimeSpan FlexTotal { get; set; }
        public string? Gender { get; set; }
    }
}
