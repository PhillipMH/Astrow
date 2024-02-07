using Astrow_Domain.DBContext;
using Astrow_Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Astrow_Services.Services
{
    public class TeacherRepository
    {
        private readonly Astrow_DomainContext _dbcontext;
        private readonly IGenericCrud _crud;
        public TeacherRepository(Astrow_DomainContext dbcontext, IGenericCrud crud)
        {
            _dbcontext = dbcontext;
            _crud = crud;
        }
        public async Task<bool> GetTeacherLogin(string unilogin, string password, bool logged)
        {
            var teacher = _crud.GenericLogin(unilogin, password);
            if (teacher == null) 
            {
                logged = false;
            }
            else if (teacher != null)
            {
                logged = true;
                //add indicater and add session to if the login was successfull
            }
            return logged;
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
            var foundteacher = _crud.GetUserById<Teachers>(teacherId);
            return foundteacher;
        }
        public async void DeleteTeacher(Guid id)
        {
            var teacher = _crud.GetUserById<Teachers>(id);
            _crud.Delete(teacher);
        }
        
    }
}
