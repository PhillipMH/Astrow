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
using Astrow.Shared.DTO;

namespace Astrow_Services.Services
{
    public class TeacherRepository : ITeacherInterface
    {
        private readonly Astrow_DomainContext _dbContext;
        private readonly IGenericCrud _crud;
        public TeacherRepository(Astrow_DomainContext dbcontext, IGenericCrud crud)
        {
            _dbContext = dbcontext;
            _crud = crud;
        }
        public async Task<Teachers> CreateTeacher(Teachers teacher)
        {
            if (teacher != null)
            {
                _crud.Create(teacher);
            }
            if (teacher == null)
            {
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
            await _crud.GetUserById<Teachers>(id);
            _crud.Update(teacher);
            return new();
        }
        public async void DeleteTeacher(Guid id)
        {
            var teacher = await _crud.GetUserById<Teachers>(id);
            _crud.Delete(teacher);
        }
        public async Task<Teachers> LoginTeacher(LoginDTO login)
        {
            var teacher = (await _dbContext.Teachers.ToListAsync()).SingleOrDefault(x => x.Unilogin == login.Unilogin && x.Password == login.Password);
            if (teacher == null)
            {
                return null;
            }
            return teacher;
        }
        
    }
}
