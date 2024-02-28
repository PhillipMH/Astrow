using Astrow.Shared.DTO;

namespace Astrow.Client.IAPICallers
{
    public interface ITeacherCaller
    {
        Task<TeacherDTO> CreateTeacher(TeacherDTO teacher);
        Task<TeacherDTO> ReadSpecificTeacher(TeacherDTO teacher);
        Task<TeacherDTO> UpdateTeacher(TeacherDTO teacher);
        void DeleteTeacher(TeacherDTO id);
        Task<bool> Login(LoginDTO loginDTO);
    }
}
