using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow_Domain.Models
{
    public class Teachers
    {
        [Key]
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public int HouseNumber { get; set; }
        public string City { get; set; } = null!; 
        public string Mail { get; set; } = null!;
        public DateTime DateOfBirth { get; set; } 
        public string? Gender { get; set; }
    }
}
