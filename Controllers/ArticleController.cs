using Frontend.Exceptions;
using Frontend.Models;
using Frontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleApiService _apiService;

        public ArticleController(IArticleApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: Article/
        public ActionResult Index()
        {
            try
            {
                var articles = _apiService.GetAll();
                return View(articles);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var article = _apiService.GetById(id);
                return View(article);
            }
            catch (ArticleNotFoundException)
            {
                return StatusCode(404, "Not Found");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleCreateViewModel article)
        {
            try
            {
                _apiService.Create(article);
                return RedirectToAction(nameof(Index));
            }
            catch (TopicNotFoundException)
            {
                ModelState.AddModelError(nameof(ArticleCreateViewModel.TopicId), "TopicId not found");
                return View(article);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var article = _apiService.GetById(id);
                ArticleCreateViewModel articleViewModel = new ArticleCreateViewModel();
                articleViewModel.Title = article.Title;
                articleViewModel.Body = article.Body;
                articleViewModel.TopicId = article.Topic.Id;
                return View(articleViewModel);
            }
            catch (ArticleNotFoundException)
            {
                return StatusCode(404, "Not Found");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST: Article/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArticleCreateViewModel article)
        {
            try
            {
                _apiService.Update(id, article);
                return RedirectToAction(nameof(Index));
            }
            catch (TopicNotFoundException)
            {
                ModelState.AddModelError(nameof(ArticleCreateViewModel.TopicId), "TopicId not found");
                return View(article);
            }
            catch (ArticleNotFoundException)
            {
                return StatusCode(404, "Not Found");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var article = _apiService.GetById(id);
                return View(article);
            }
            catch (ArticleNotFoundException)
            {
                return StatusCode(404, "Not Found");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST: Article/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _apiService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ArticleNotFoundException)
            {
                return StatusCode(404, "Not Found");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
