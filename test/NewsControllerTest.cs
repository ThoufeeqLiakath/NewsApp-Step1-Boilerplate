using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using News_WebApp.Repository;
using Xunit;
using Moq;
using News_WebApp.Models;
using System;
using News_WebApp.Controllers;
using System.Threading.Tasks;
namespace Test
{
    public class NewsControllerTest
    {
        [Fact]
        public void GetShouldReturnListOfNews()
        {
            var mockRepo = new Mock<INewsRepository>();
            mockRepo.Setup(repo => repo.GetAllNews()).Returns(this.newsList);
            var newsController = new NewsController(mockRepo.Object);

            var actual = newsController.Index();

            var actionResult = Assert.IsType<ViewResult>(actual);
            Assert.NotNull(actionResult.ViewData.Values);
        }
     
        [Fact]
        public void PostShouldAddNews()
        {
            var mockRepo = new Mock<INewsRepository>();
            var news = new News { Title = "2020 FIFA U-17 Women World Cup", Content = "The tournament will be held in India between 2 and 21 November 2020.", PublishedAt = DateTime.Now, UrlToImage = null };
            mockRepo.Setup(repo => repo.AddNews(news)).Returns(new News { NewsId = 102, Title = "2020 FIFA U-17 Women World Cup", Content = "The tournament will be held in India between 2 and 21 November 2020.", PublishedAt = DateTime.Now, UrlToImage = null });

            var newsController = new NewsController(mockRepo.Object);

            var actual = newsController.Index(news);

            var actionResult = Assert.IsType<RedirectToActionResult>(actual);
            Assert.Equal("Index", actionResult.ActionName);
        }
        [Fact]
        public void DeleteShouldReturnToIndex()
        {
            int newsId = 101;
            var mockRepo = new Mock<INewsRepository>();
            mockRepo.Setup(repo => repo.RemoveNews(newsId)).Returns(true);
            var newsController = new NewsController(mockRepo.Object);

            var actual = newsController.Delete(newsId);

            var actionResult = Assert.IsType<RedirectToActionResult>(actual);
            Assert.Null(actionResult.ControllerName);
            Assert.Equal("Index", actionResult.ActionName);
        }

        private readonly List<News> newsList = new List<News> {
                new News { Title= "IT industry in 2020", Content= "It is expected to have positive growth in 2020.", PublishedAt= DateTime.Now, UrlToImage=null },
                new News { Title = "2020 FIFA U-17 Women World Cup", Content = "The tournament will be held in India between 2 and 21 November 2020.", PublishedAt = DateTime.Now, UrlToImage = null }
        };
    }
}
