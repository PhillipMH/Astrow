using Astrow.Shared.DTO;
using Astrow_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow_Services.Interfaces
{
    public interface ITeacherInterface
    {
        Task<Teachers> CreateTeacher(Teachers teacher, bool teacherCreated);
        Task<Teachers> ReadSpecificTeacher(Guid teacherId);
        Task<Teachers> UpdateStudent(Teachers teacher, Guid id);
        void DeleteTeacher(Guid id);
        Task<Teachers> LoginTeacher(LoginDTO login);
    }
}
