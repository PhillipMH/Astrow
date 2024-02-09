﻿using Astrow_Domain.DBContext;
using Astrow_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Astrow_Domain.DBContext;

namespace Astrow_Services.Services
{
    public class StudentRepository
    {
        
        private readonly IGenericCrud _crud;
        private readonly Astrow_DomainContext _dbContext;
        public StudentRepository(IGenericCrud crud, Astrow_DomainContext dbcontext)
        {
            _crud = crud;
            _dbContext = dbcontext;
        }
        public async Task<bool> GetStudentLogin(string unilogin, string password, bool loginsuccess = false)
        {
            var student = await _crud.GenericLogin(unilogin, password);

            return student;
        }
        public async Task<Students> CreateStudent(Students student)
        {
            if (student != null)
            {
                _crud.Create(student);
                //add toast in frontend to indicate that user has been added
            }
            else if(student == null)
            {
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
            _crud.GetUserById<Students>(id);
            _crud.Update(student);
            return new();
        }
        public async Task<Students> DeleteStudent(Guid studentid)
        {
            _crud.Delete(studentid);
            return new();
        }
        public async Task<Students> LoginStudents(string unilogin, string password)
        {
            var student = await _dbContext.Students
                .SingleOrDefaultAsync(s => s.Unilogin == unilogin && s.Password == password)
        }

    }
}
