using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_WebApp.Models;
using News_WebApp.Repository;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace News_WebApp.Controllers
{
    public class NewsController : Controller
    {
        /*
          * From the problem statement, we can understand that the application
          * requires us to implement the following functionalities.
          * 
          * 1. Display the list of existing news from the collection. Each news 
          *    should contain NewsId, title, content,PublishedAt and UrlToImage.
          * 2. Add a new news which should contain the Newsid, title, content and PublishedAt
          *    and upload a image using UrlToImage property.
          *    Note:uploaded image strore it in wwwroot/images folder
          *    
          * 3. Delete an existing News.
      */
        private INewsRepository _newsRepository;


        /* 
         * Retrieve the NewsRepository object from the dependency Container through constructor Injection.
         */
        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        /*Define a handler method to read the existing News by calling the GetNews() method 
         * of the NewsRepository class and pass to view. it should map to the default URL i.e. "/" */

        [HttpGet]
        public IActionResult Index()
        {
            var news = new News();
            news.AllNews = GetNews();            
            return View(news);
        }

        private List<News> GetNews()
        {
            var allNews = _newsRepository.GetAllNews();
            return allNews;
        }

        [HttpPost]
        public IActionResult Index(News news)
        {
            //if(ModelState.IsValid)
            //{
            var newsId = 101;
            var newsList = _newsRepository.GetAllNews();
            for (int x = 101; x < 10000; x++)
            {
                var find = newsList?.Where(c => c.NewsId == x).FirstOrDefault();
                if (find == null)
                {
                    newsId = x;
                    break;
                }
            }
            if (news != null)
            {
                if (System.IO.File.Exists(news.UrlToImage))
                {
                    FileInfo fi = new FileInfo(news.UrlToImage);
                    var fileContent = System.IO.File.ReadAllBytes(news.UrlToImage);
                    var path = Path.GetFullPath("wwwroot/images");

                    news.UrlToImage = $"/images/{newsId + 1}{fi.Extension}";
                    System.IO.File.WriteAllBytes($"{path}\\{newsId + 1}{fi.Extension}", fileContent);

                }
                else
                {
                    news.UrlToImage = "dummy";
                }
                _newsRepository.AddNews(news);
            }
            return RedirectToAction("Index");

        }


        /*Define a handler method which will accept newsid as a parameter 
         * and return the available news details of the newsid by calling the GetNewsById() of News
         * Repository class
        */
        [HttpGet]
        [Route("news/details/{Id:int}")]
        public IActionResult GetNewsById(int Id)
        {
            var currentNews = _newsRepository.GetNewsById(Id);
            return View(currentNews);
        }

        /* Define a handler method to delete an existing News by calling the RemoveNews() method 
         * of the NewsRepository class
        */
        [Route("news/delete/{newsId}")]
        public IActionResult Delete(int newsId)
        {
            var newsToBeDeleted = _newsRepository.RemoveNews(newsId);
            return RedirectToAction("Index");
        }
    }
}
