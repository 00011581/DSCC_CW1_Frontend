using Frontend.Exceptions;
using Frontend.Models;
using Frontend.Services;
using Microsoft.AspNetCore.Http;
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

        // GET: ArticleController
        public ActionResult Index()
        {
            var articles = _apiService.GetAll();
            return View(articles);
        }

        // GET: ArticleController/Details/5
        public ActionResult Details(int id)
        {
            var article = _apiService.GetById(id);
            return View(article);
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleController/Create
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
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
