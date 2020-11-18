using News_WebApp.Models;
using System.Collections.Generic;

namespace News_WebApp.Repository
{
    /*
	 * Should not modify this interface. You have to implement these methods of interface 
     * in corresponding Implementation classes
	 */
    public interface INewsRepository
    {
        News AddNews(News news);
        News GetNewsById(int newsId);
        List<News> GetAllNews();
        bool RemoveNews(int newsId);
    }
}
