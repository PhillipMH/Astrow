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
using Astrow_Services.Interfaces;
using Astrow.Shared.DTO;
using System.Security.Cryptography.X509Certificates;
using Astrow_Services.Services.Mapping;
using AutoMapper;

namespace Astrow_Services.Services
{
    public class StudentRepository : IStudentInterface
    {
        private readonly MappingService _mapper;
        private readonly IGenericCrud _crud;
        private readonly Astrow_DomainContext _dbContext;
        public StudentRepository(IGenericCrud crud, Astrow_DomainContext dbcontext)
        {
            _crud = crud;
            _dbContext = dbcontext;
        }
        public async Task<StudentDTO> CreateStudent(StudentDTO student)
        {
            Students tempstudent = new Students();
            tempstudent.StudentId = Guid.NewGuid();
            tempstudent.Unilogin = student.Unilogin;
            tempstudent.FirstName = student.FirstName;
            tempstudent.LastName = student.LastName;
            tempstudent.City = student.City;
            tempstudent.HouseNumber = student.HouseNumber;
            tempstudent.Password = student.Password;
            tempstudent.FlexTotal = student.FlexTotal;
            tempstudent.StreetName = student.StreetName;


            if (await CheckIfStudentExists(tempstudent.Unilogin))
            {
                Console.WriteLine("Duplicate Unilogin");
            }
            else
            {
                try
                {
                    _crud.Create(tempstudent);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return new();
        }

        public async Task<Students> ReadSpecificStudent(Guid studentId)
        {
            var founduser = await _crud.GetUserById<Students>(studentId);
            return founduser;
        }

        public async Task<Students> UpdateStudent(Students student, Guid id)
        {
            await _crud.GetUserById<Students>(id);
            _crud.Update(student);
            return new();
        }

        public async Task<Students> DeleteStudent(string unilogin)
        {
            _crud.Delete(unilogin);
            return new();
        }

        public async Task<Students> LoginStudents(LoginDTO login)
        {
            var student = (await _dbContext.Students.ToListAsync()).SingleOrDefault(x => x.Unilogin == login.Unilogin && x.Password == login.Password);
            if (student == null)
            {
                return null;
            }
            return student;
        }

        public List<Students> GetAllStudents()
        {
            try
            {
                var response = _dbContext.Students.AsNoTracking().ToList();
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        public async Task<bool> CheckIfStudentExists(string unilogin)
        {
            return await _dbContext.Students.AnyAsync(s => s.Unilogin == unilogin);
        }
    }
}
