using MovieTask.Entities;
using MovieTask.Services.Abstract;
using MovieTask.Services.Concrete;
using System.Text.Json;

namespace MovieTask.Services
{
    public class GetMovieService
    {
        private readonly HttpClient httpClient;
        private readonly Random random;

        public GetMovieService()
        {
            httpClient = new HttpClient();
            random = new Random();
        }

        public async Task<Movie> GetMovieFromApi()
        {
            char randomLetter = (char)('A' + random.Next(26));

            string apiKey = "573749c3";
            string apiUrl = $"https://www.omdbapi.com/?apikey={apiKey}&t={randomLetter}*";

            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var movieInfo = JsonSerializer.Deserialize<Movie>(content);
                return movieInfo;
            }
            else
            {
                return null;
            }
        }
    }
}