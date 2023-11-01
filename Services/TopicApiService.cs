using Frontend.Models;
using Newtonsoft.Json;

namespace Frontend.Services
{
    public class TopicApiService : ITopicApiService
    {
        private readonly string _apiBaseUrl;
        private readonly HttpClient _httpClient;

        public TopicApiService(IConfiguration configuration, HttpClient httpClient)
        {
            _apiBaseUrl = configuration["APIBaseUrl"];
            _httpClient = httpClient;
        }

        public ICollection<Topic> GetAll()
        {
            HttpResponseMessage response = _httpClient.GetAsync(_apiBaseUrl + "Topics").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Topic>>(responseContent);
            }
            else
            {
                return null;
            }
        }
    }
}
