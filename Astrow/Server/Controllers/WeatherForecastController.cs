using Astrow.Shared;
using Astrow.Shared.DTO;
using Astrow_Domain.Models;
using Astrow_Services.Interfaces;
using Astrow_Services.Services;
using Microsoft.AspNetCore.Mvc;

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
                return Ok();
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
    }
}