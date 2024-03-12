using Astrow.Shared.DTO;
using Astrow_Domain.Models;

namespace Astrow.Client.IAPICallers
{
    public interface IStudentCaller
    {
        Task<StudentDTO> CreateStudent(StudentDTO student);
        Task<StudentDTO> ReadSpecificStudent(StudentDTO student);
        Task<StudentDTO> UpdateStudent(StudentDTO student);
        Task DeleteStudent(StudentDTO unilogin);
        Task<bool> Login(LoginDTO loginDTO);
        Task<List<StudentDTO>> GetAllStudents();
        Task<StudentDTO> RegisterStudentSick(StudentDTO student);
    }
}
