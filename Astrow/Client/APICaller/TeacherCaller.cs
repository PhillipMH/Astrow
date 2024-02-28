using Astrow.Client.IAPICallers;
using Astrow.Shared.DTO;
using System.Net.Http.Json;
using System.Text.Json;

namespace Astrow.Client.APICaller
{
    public class TeacherCaller : ITeacherCaller
    {
        private HttpClient _client;
        public TeacherCaller(HttpClient client)
        {
            _client = client;
        }
        public async Task<TeacherDTO> CreateTeacher(TeacherDTO teacher)
        {
            try
            {
                var response = await _client.PostAsJsonAsync<TeacherDTO>("WeatherForecast", teacher);
                response.EnsureSuccessStatusCode();
                return teacher;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<TeacherDTO> ReadSpecificTeacher(TeacherDTO teacher)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("WeatherForecast", teacher);
                response.EnsureSuccessStatusCode();
                return teacher;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<TeacherDTO> UpdateTeacher(TeacherDTO teacher)
        {
            try
            {
                //try json serializing

                var response = await _client.PutAsJsonAsync("WeatherForecast", teacher);
                response.EnsureSuccessStatusCode();
                return teacher;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async void DeleteTeacher(TeacherDTO id)
        {
            try
            {
                var response = await _client.PostAsJsonAsync<TeacherDTO>("WeatherForecast", id);
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
                var response = await _client.PostAsJsonAsync("WeatherForecast/TeacherLogin", loginDTO);

                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
