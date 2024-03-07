using Astrow.Shared.DTO;
using Astrow_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow_Services.Interfaces
{
    public interface IStudentInterface
    {
        Task<StudentDTO> CreateStudent(StudentDTO student);
        Task<Students> ReadSpecificStudent(Guid studentId);
        Task<Students> UpdateStudent(Students student, Guid id);
        Task<Students> DeleteStudent(Guid studentid);
        Task<Students> LoginStudents(LoginDTO login);
        Task<List<Students>> GetAllStudents();
    }
}

