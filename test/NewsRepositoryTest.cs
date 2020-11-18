using News_WebApp.Models;
using News_WebApp.Repository;
using System;
using Xunit;

namespace Test
{
    public class NewsRepositoryTest
    {
        private readonly NewsRepository newsRepository;
        public NewsRepositoryTest()
        {
            newsRepository = new NewsRepository();
        }

        [Fact]
        public void AddNewsShouldSuccess()
        {
            News news = new News { Title= "IT industry in 2020", Content= "It is expected to have positive growth in 2020.", PublishedAt= DateTime.Now, UrlToImage=null };
            var actual= newsRepository.AddNews(news);
            Assert.Equal(101, actual.NewsId);
            Assert.NotNull(newsRepository.GetNewsById(101));


        }

        [Fact]
        public void DeleteNoteShouldSuccess()
        {
            News news = new News { Title = "IT industry in 2020", Content = "It is expected to have positive growth in 2020.", PublishedAt = DateTime.Now, UrlToImage = null };
            newsRepository.AddNews(news);
            Assert.NotNull(newsRepository.GetNewsById(101));

            var status= newsRepository.RemoveNews(101);
            Assert.True(status);
            Assert.Null(newsRepository.GetNewsById(101));
        }

        [Fact]
        public void GetNewsShouldReturnList()
        {
            News news = new News { Title = "IT industry in 2020", Content = "It is expected to have positive growth in 2020.", PublishedAt = DateTime.Now, UrlToImage = null };
            newsRepository.AddNews(news);

            News news2 = new News { Title = "2020 FIFA U-17 Women World Cup", Content = "The tournament will be held in India between 2 and 21 November 2020.", PublishedAt = DateTime.Now, UrlToImage = null };
            newsRepository.AddNews(news2);

            var newslist = newsRepository.GetAllNews();
            Assert.Equal(2, newslist.Count);
        }
    }
}
