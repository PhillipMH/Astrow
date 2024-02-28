using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow_Domain.Models
{
    public class Students
    {
        [Key]
        public Guid StudentId { get; set; }
        public string Unilogin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public TimeSpan FlexTotal { get; set; }
        public string Password { get; set; }
        public string? Gender { get; set; }
        public bool IsSick { get; set; } = false;
        public RegisterSick? RegisteredSick { get; set; }
    }
}
