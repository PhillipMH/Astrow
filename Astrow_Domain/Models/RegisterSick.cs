using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow_Domain.Models
{
    public class RegisterSick
    {
        public string Name { get; set; }
        public string SickReason { get; set; }
        public Guid PersonId { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime TimeRegistered { get; set; }
        public enum Type {Student, Teacher}

    }
}
