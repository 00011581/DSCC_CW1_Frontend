using Frontend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicApiService _apiService;

        public TopicController(ITopicApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: TopicController
        public ActionResult Index()
        {
            try
            {
                var topics = _apiService.GetAll();
                return View(topics);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
