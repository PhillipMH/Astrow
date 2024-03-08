using Astrow.Client.IAPICallers;
using Astrow.Shared.DTO;
using Astrow_Domain.Models;
using Azure;
using System.Net.Http.Json;
using System.Text.Json;

namespace Astrow.Client.APICaller
{
    public class StudentCaller : IStudentCaller
    {
        private readonly HttpClient _client;
        public StudentCaller(HttpClient client)
        {
            _client = client;
        }
        public async Task<StudentDTO> CreateStudent(StudentDTO student)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("WeatherForecast/CreateStudent", student);
                response.EnsureSuccessStatusCode();
                return student;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<StudentDTO> ReadSpecificStudent(StudentDTO student)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("WeatherForecast", student);
                response.EnsureSuccessStatusCode();
                return student;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<StudentDTO> UpdateStudent(StudentDTO student)
        {
            try
            {
                //try json serializing

                var response = await _client.PutAsJsonAsync("WeatherForecast", student);
                response.EnsureSuccessStatusCode();
                return student;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task DeleteStudent(StudentDTO unilogin)
        {
            try
            {
                var response = await _client.DeleteAsync($"WeatherForecast/DeleteStudent/{unilogin}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<bool> Login(LoginDTO loginDTO)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("WeatherForecast/Login", loginDTO);

                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public async Task<List<StudentDTO>> GetAllStudents()
        {
            try
            {
                var response = await _client.GetFromJsonAsync<List<StudentDTO>>("WeatherForecast/GetAllStudents");
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

}
