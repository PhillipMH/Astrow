using Astrow.Shared;
using Astrow.Shared.DTO;
using Astrow_Domain.Models;
using Astrow_Services.Interfaces;
using Astrow_Services.Services;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Astrow.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ITeacherInterface _teachers;
        private readonly IStudentInterface _students;
        public string Unilogin { get; set; }
        public string Password { get; set; }
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStudentInterface student, ITeacherInterface teacher)
        {
            _logger = logger;
            _students = student;
            _teachers = teacher;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var studentnew = await _students.LoginStudents(loginDTO);
            if (studentnew != null)
            {
                Console.WriteLine("suc");
                return Ok(studentnew);
            }
            else
            {
                Console.WriteLine("not suc");
                return NotFound();
            }
        }
        [HttpPost]
        [Route("TeacherLogin")]
        public async Task<IActionResult> TeacherLogin(LoginDTO loginDTO)
        {
            var studentnew = await _teachers.LoginTeacher(loginDTO);
            if (studentnew != null)
            {
                Console.WriteLine("suc");
                return Ok();
            }
            else
            {
                Console.WriteLine("not suc");
                return NotFound();
            }

        }
        [HttpPost]
        [Route("CreateStudent")]
        public async Task<StudentDTO> CreateStudent(StudentDTO newstudent)
        {
            newstudent = await _students.CreateStudent(newstudent);

            return newstudent;
        }
        [HttpGet]
        [Route("ReadStudent")]
        public async Task<Students> ReadSpecificStudent(string unilogin)
        {
            var no = await _students.ReadSpecificStudent(unilogin);
            return no;
        }
        [HttpDelete]
        [Route("DeleteStudent")]
        public async Task DeleteStudent(StudentDTO unilogin)
        {
            try
            {
                var temp = await _students.DeleteStudent(unilogin);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            try
            {
                return Ok(_students.GetAllStudents());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpPost]
        [Route("RegisterStudentSick")]
        public async Task<Students> RegisterStudentSick(Students student)
        {
            try
            {
                var no = _students.RegisterStudentSick(student);
                return student;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}