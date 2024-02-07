using Astrow_Services.Services;
using Microsoft.AspNetCore.Mvc;
using Astrow.Shared.DTO;
using Astrow_Domain.Models;

namespace Astrow_WebApi.Controllers
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

        private readonly IGenericCrud _crud;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IGenericCrud crud)
        {
            _logger = logger;
            _crud = crud;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] TeacherDTO newteacher)
        {
            _crud.Create(newteacher);
            return Ok();
        }
        [HttpPost]
        [Route("Read")]
        public IActionResult ReadUserById([FromQuery] Guid id)
        {
            var foundteacher = _crud.GetUserById<Teachers>(id);
            Console.WriteLine(foundteacher);
            return Ok();
        }
        [HttpPost]
        [Route("Update")]
        public IActionResult Update([FromBody] TeacherDTO updateduser, [FromQuery] Guid id)
        {
            TeacherDTO newuser = _crud.GetUserById<TeacherDTO>(id);
            newuser = updateduser;
            _crud.Update(newuser);
            return Ok();
        }
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([FromQuery] Guid id)
        {
            StudentDTO user = _crud.GetUserById<StudentDTO>(id);
            if (user == null)
            {
                return NotFound();
            }

            _crud.Delete(user);
            return Ok();
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromQuery] string unilogin, [FromQuery] string password)
        {
            bool teacherlogin = await _crud.GenericLogin(unilogin, password);
            if (teacherlogin == true)
            {
                return Ok();
            }
            if (teacherlogin == false)
            {
                return NotFound();
            }
            return null;
        }
    }
}