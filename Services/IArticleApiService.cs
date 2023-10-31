using Frontend.Models;

namespace Frontend.Services
{
    public interface IArticleApiService
    {
        public ICollection<Article> GetAll();
        public Article GetById(int id);
        public void Create(Article article);
        public void Update(Article article);
        public void Delete(int id);
    }
}
