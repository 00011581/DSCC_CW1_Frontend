using Frontend.Models;

namespace Frontend.Services
{
    public interface ITopicApiService
    {
        ICollection<Topic> GetAll();
    }
}
