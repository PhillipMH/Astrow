using Microsoft.AspNetCore.Mvc;
using Astrow.Shared.DTO;
using Astrow_Domain.Models;
using AutoMapper;
using Astrow_Services.Interfaces;

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

        private readonly IGenericCrud _crud;
        private readonly IMapper _mapper;
        public WeatherForecastController( IGenericCrud crud, IMapper mapper)
        {
            _mapper = mapper;
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
        public Task<Teachers> Update([FromBody] Teachers updateduser, [FromQuery] Guid id)
        {
            //Teacnewuser = _crud.GetUserById<Teachers>(id);
            //newuser = updateduser;
            //_crud.Update(newuser);
            //return Ok();
            return null;
        }
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([FromQuery] Guid id)
        {
            //StudentDTO user = _crud.GetUserById<StudentDTO>(id);
            //if (user == null)
            //{
            //    return NotFound();
            //}

            /*_crud.Delete(user)*/;
            return Ok();
        }
        [HttpGet]
        [Route("Read Dto")]
        public ActionResult GetDtos()
        {
            return Ok();
        }
    }
}