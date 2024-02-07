using Astrow_Domain.DBContext;
using Astrow_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow_Services.Services
{
    public class StudentRepository
    {
        private readonly Astrow_DomainContext _dbcontext;
        private readonly IGenericCrud _crud;
        public StudentRepository(Astrow_DomainContext dbcontext, IGenericCrud crud)
        {
         _dbcontext = dbcontext;
         _crud = crud;
        }
        public async Task<bool> GetStudentLogin(string unilogin, string password, bool loginsuccess = false)
        {
            var student = await _crud.GenericLogin(unilogin, password);
            if (student == null)
            {
                loginsuccess = false;
                //add toast in frontend to indicate that something is wrong
            }
            if (student != null)
            {
                loginsuccess = true;
                //add toast in frontend to indicate that login was successfull
            }
            return loginsuccess;
        }
        public async Task<Students> CreateStudent(Students student, bool studentcreated)
        {
            if (student != null)
            {
                _crud.Create(student);
                studentcreated = true;
                //add toast in frontend to indicate that user has been added
            }
            else if(student == null)
            {
                studentcreated = false;
                return new();
                //add toast in frontend to indicate that user wasnt created
            }
            return student;
        }
        public async Task<Students> ReadSpecificStudent(Guid studentId)
        {
            var founduser = _crud.GetUserById<Students>(studentId);
            return founduser;
        }
        public async Task<Students> UpdateStudent(Students student, Guid id)
        {
            _crud.Update(student);
            return new();
        }
        public async Task<Students> DeleteStudent(Guid studentid)
        {
            _crud.Delete(studentid);
            return new();
        }

    }
}
