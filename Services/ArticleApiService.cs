using Frontend.Exceptions;
using Frontend.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace Frontend.Services
{
    public class ArticleApiService : IArticleApiService
    {
        private readonly string _apiBaseUrl;
        private readonly HttpClient _httpClient;

        public ArticleApiService(IConfiguration configuration, HttpClient httpClient)
        {
            _apiBaseUrl = configuration["APIBaseUrl"];
            _httpClient = httpClient;
        }

        public void Create(ArticleCreateViewModel article)
        {
            var articleJSON = JsonConvert.SerializeObject(article);
            var content = new StringContent(articleJSON, Encoding.UTF8, "application/json");
            var response = _httpClient.Send(
                new HttpRequestMessage(HttpMethod.Post, _apiBaseUrl + "Articles") { Content = content}
            );

            if (response.StatusCode.ToString() == "BadRequest")
            {
                throw new TopicNotFoundException("TopicId doesn't exist");
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Article> GetAll()
        {
            HttpResponseMessage response = _httpClient.GetAsync(_apiBaseUrl + "Articles").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Article>>(responseContent);
            }
            else
            {
                return null;
            }
        }

        public Article GetById(int id)
        {
            HttpResponseMessage response = _httpClient.GetAsync(_apiBaseUrl + $"Articles/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Article>(responseContent);
            }
            else
            {
                return null;
            }
        }

        public void Update(ArticleCreateViewModel article)
        {
            throw new NotImplementedException();
        }
    }
}
