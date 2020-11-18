using Microsoft.AspNetCore.Mvc.Testing;
using News_WebApp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Test;
using Xunit;

namespace Test
{
    [TestCaseOrderer("Test.PriorityOrderer", "test")]
    public class NewsControllerIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        public NewsControllerIntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact, TestPriority(2)]
        public async Task LandingPageShouldDisplayForm()
        {
            // Act
            var response = await _client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            MatchCollection groups= Regex.Matches(responseString, $"<div class=\"form-group\">");
            Assert.Equal(5, groups.Count);
            MatchCollection inputs = Regex.Matches(responseString, "<input .+ type=\"text\"");
            Assert.Equal(2, inputs.Count);
            Assert.Contains("form", responseString);
            Assert.Contains("Title", responseString);
            Assert.Contains("Content", responseString);
            Assert.Contains("PublishedAt", responseString);
            Assert.Contains("<label class=\"control-label\">Select an image to upload</label>", responseString);
            Assert.Contains("input type=\"file\"", responseString);
            Assert.Contains("table", responseString);
        }

        [Fact, TestPriority(1)]
        public async Task PostShouldAddNews()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/");
            var formModel = new Dictionary<string, string>
                {
                    { "Title", "IT industry in 2020" },
                    { "Content", "It is expected to have positive growth in 2020."},
                    {"PublishedAt",DateTime.Now.ToString()}
                };

            postRequest.Content = new FormUrlEncodedContent(formModel);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("table", responseString);
            Assert.Contains("IT industry in 2020", responseString);
        }

        [Fact, TestPriority(3)]
        public async Task DetailsPageShouldDisplaySingleNews()
        {
            //Arrange
            int id = 101;
            // Act
            var response = await _client.GetAsync($"/news/details/{id}");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("IT industry in 2020", responseString);
            Assert.Contains("It is expected to have positive growth in 2020.",responseString);
        }

        [Fact, TestPriority(4)]
        public async Task DeleteShouldRemoveNews()
        {
            //Arrange
            int id = 101;
            // Act
            var response = await _client.GetAsync($"/news/delete/{id}");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            MatchCollection groups = Regex.Matches(responseString, $"<div class=\"form-group\">");
            Assert.Equal(5, groups.Count);
            MatchCollection inputs = Regex.Matches(responseString, "<input .+ type=\"text\"");
            Assert.Equal(2, inputs.Count);
            Assert.Contains("form", responseString);
            Assert.Contains("Title", responseString);
            Assert.Contains("Content", responseString);
            Assert.Contains("PublishedAt", responseString);
            Assert.Contains("<label class=\"control-label\">Select an image to upload</label>", responseString);
            Assert.Contains("input type=\"file\"", responseString);
            Assert.Contains("table", responseString);
        }
    }
}
