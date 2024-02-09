using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow.Shared.DTO
{
    public class TeacherDTO 
    {
        public Guid UserId { get; set; }
        public string Unilogin { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string HouseNumber { get; set; }
        public string Mail { get; set; }
    }
}
