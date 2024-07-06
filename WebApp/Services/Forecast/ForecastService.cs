
using Newtonsoft.Json;
using WebApp.Dto;

namespace WebApp.Services.Forecast
{
    public class ForecastService : IForecastService
    {
        private readonly HttpClient _httpClient;
        
        public ForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<WeatherForecast>?> GetForecastsAsync()
        {
            var response = await _httpClient.GetAsync("WeatherForecast");

            return JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(await response.Content.ReadAsStringAsync());
        }
    }
}
