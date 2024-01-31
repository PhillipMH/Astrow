using Astrow_Domain.DBContext;
using Astrow_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow_Domain.Repositories
{
    public class StudentRepository
    {
        private readonly Astrow_DomainContext _dbcontext;
        public StudentRepository(Astrow_DomainContext dbcontext)
        {
         _dbcontext = dbcontext;
        }
        public async Task<Students> GetStudentLogin(string unilogin, string password, bool loginsuccess = false)
        {
            var student = await _dbcontext.Students
                .SingleOrDefaultAsync(u => u.Unilogin == unilogin && u.Password == password);
            if (student == null)
            {
                loginsuccess = false;
                //add toast here to indicate that something is wrong
            }
            if (student != null)
            {
                loginsuccess = true;
                //add toast here to indicate that login was successfull
            }
            return new();
        }
        //public async Task<Students> AddUserToDb()
        //{
              
        //}
    }
}
