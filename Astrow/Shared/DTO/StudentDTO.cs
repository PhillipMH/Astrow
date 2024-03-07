using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow.Shared.DTO
{
    public class StudentDTO
    {
        public Guid StudentId { get; set; }
        [MinLength(4)]
        [MaxLength(12)]
        public string Unilogin { get; set; }
        [MinLength(1)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MinLength(1)]
        [MaxLength(20)]
        public string LastName { get; set; }
        [MinLength(1)]
        [MaxLength(35)]
        public string StreetName { get; set; }
        [Range(0, 1000)]
        public int HouseNumber { get; set; }
        [MinLength(1)]
        [MaxLength(30)]
        public string City { get; set; }
        [MinLength(8)]
        [MaxLength(30)]
        public string Password { get; set; }
        public TimeSpan FlexTotal { get; set; }

    }
}
