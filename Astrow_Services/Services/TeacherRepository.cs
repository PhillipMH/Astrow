using Astrow_Domain.DBContext;
using Astrow_Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Astrow_Services.Interfaces;

namespace Astrow_Services.Services
{
    public class TeacherRepository : ITeacherInterface
    {
        private readonly Astrow_DomainContext _dbcontext;
        private readonly IGenericCrud _crud;
        public TeacherRepository(Astrow_DomainContext dbcontext, IGenericCrud crud)
        {
            _dbcontext = dbcontext;
            _crud = crud;
        }
        public async Task<Teachers> CreateTeacher(Teachers teacher, bool teacherCreated)
        {
            if (teacher != null)
            {
                _crud.Create(teacher);
                teacherCreated = true;
            }
            if (teacher == null)
            {
                teacherCreated = false;
                return new();
                //add toast to frontend to indicate that something went wrong
            }
            return teacher;
        }
        public async Task<Teachers> ReadSpecificTeacher(Guid teacherId)
        {
            var foundteacher = await _crud.GetUserById<Teachers>(teacherId);
            return foundteacher;
        }
        public async Task<Teachers> UpdateStudent(Teachers teacher, Guid id)
        {
            _crud.GetUserById<Teachers>(id);
            _crud.Update(teacher);
            return new();
        }
        public async void DeleteTeacher(Guid id)
        {
            var teacher = _crud.GetUserById<Teachers>(id);
            _crud.Delete(teacher);
        }
        public async Task<Teachers> LoginTeacher(string unilogin, string password)
        {
            var teacher = await _dbcontext.Teachers
                .SingleOrDefaultAsync(t => t.Unilogin == unilogin && t.Password == password);

            return teacher;
        }
        
    }
}
