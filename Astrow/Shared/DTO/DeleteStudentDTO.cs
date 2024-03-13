using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow.Shared.DTO
{
    public class DeleteStudentDTO
    {
        public Guid id { get; set; }
        [MinLength(4)]
        [MaxLength(12)]
        public string Unilogin { get; set; }
        [MinLength(1)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MinLength(1)]
        [MaxLength(20)]
        public string LastName { get; set; }
    }
}
