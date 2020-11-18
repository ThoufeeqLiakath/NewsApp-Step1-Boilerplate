using News_WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace News_WebApp.Repository
{
    /*
      This class contains the code for data storage interactions and methods 
      of this class will be used by other parts of the applications such
      as Controllers and Test Cases
    */

    /* Inherit the respective interface and implement the methods in
    this class i.e NewsRepository by inheriting INewsRepository
     */
    public class NewsRepository:INewsRepository
    {
        /* Declare a variable of List type to store all the news. */
        private static List<News> newsList=new List<News>();
        //private int NewsId = 100;
        /*
	        This method should accept News object as argument and add the new news object into the list
	    */
        public News AddNews(News news)
        {
            var newsListLocal =new List<News>();
            if(news!=null)
            {
                news.NewsId = 101;
                newsListLocal.Add(news);
            }
            foreach(var newsCurrent in newsList)
            {
                var localNews = newsCurrent;
                localNews.NewsId = 101 + newsListLocal.Count();
                newsListLocal.Add(localNews);
            }
            newsList = newsListLocal;
            return news;
        }

        /* This method should return all the news in the list */
        public List<News> GetAllNews()
        {
            return newsList;
        }
        /*
           This method should return the matching newsid details present in the list 
        */
        public News GetNewsById(int newsId)
        {
            var currentNews = newsList.Where(x => x.NewsId == newsId).FirstOrDefault();
            if(currentNews!=null)
            {
                return currentNews;
            }
            return null;
        }
        

        /* This method should delete a specified news from the list */
        public bool RemoveNews(int newsId)
        {
            var currentNews=GetNewsById(newsId);
            newsList.Remove(currentNews);
            return true;
        }
    }
}
