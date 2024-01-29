using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow_Domain.Models
{
    public class RegisterArrivedAndLeft
    {
        public string Name { get; set; }
        public Guid PersonId { get; set; }
        public DateTime timeregistered { get; set; }
        public enum PersonType { Student, Teacher }
        public enum RegisterType {Arrived, Left}
        
    }
}
