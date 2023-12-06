using MovieTask.Services.Abstract;

namespace MovieTask.Services.Concrete
{
    public class GetMovieService
    {
        private readonly HttpClient httpClient;
        private readonly Random random;
        private readonly IMovieService _movieService;

        public GetMovieService(IMovieService movieService)
        {
            httpClient = new HttpClient();
            random = new Random();
            _movieService = movieService;
        }

        public async Task GetMovieFromApi()
        {
            char randomLetter = (char)('A' + random.Next(26));

            string apiKey = "3b5c7291";
            string apiUrl = $"https://www.omdbapi.com/?apikey={apiKey}&t={randomLetter}*";

            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
            }
            else
            {

            }
        }
    }
}