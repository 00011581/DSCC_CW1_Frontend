using Frontend.Models;

namespace Frontend.Services
{
    public interface IArticleApiService
    {
        public ICollection<Article> GetAll();
        public Article GetById(int id);
        public void Create(ArticleCreateViewModel article);
        public void Update(int Id, ArticleCreateViewModel article);
        public void Delete(int id);
    }
}
