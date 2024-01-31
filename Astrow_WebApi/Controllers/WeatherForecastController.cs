using Astrow_Domain.DBContext;
using Astrow_Domain.Models;
using Astrow_Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create([FromBody] Teachers newteacher)
        {
            _crud.Create(newteacher);
            return Ok();
        }
        [HttpPost]
        [Route("Update")]
        public IActionResult Update([FromBody] Teachers updatedteacher, [FromQuery] Guid id)
        {
            
            Teachers teacher = _crud.GetTeacherById(id);
            teacher = updatedteacher;
            _crud.Update(teacher);
            return Ok();
        }
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([FromQuery] Guid id) 
        {
            Teachers teacher = _crud.GetTeacherById(id);
            _crud.Delete(teacher);
            return Ok();
        }
    }
}