using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PublicAPITestTask
{
    /// <summary>
    /// Test are using sample public apis https://jsonplaceholder.typicode.com
    /// </summary>
    [TestClass]
    public class PublicApiTestTask
    {
        private static string url = "https://jsonplaceholder.typicode.com/";
        private HttpClient client = null;

        [TestInitialize()]
        public void TestInitialize()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// Turns out that VisualStudio.TestTools.UnitTesting framework does not recognise
        /// method as a test if it has 'async' keyword in the signature, so instead of using await
        /// I have to use .Result (should have used XUnit...).
        /// Method gets all posts
        /// </summary>
        [TestMethod]
        public void GetAllPosts_Test()
        {            
            var fullUrl = url + "posts";
            var response = client.GetAsync(fullUrl).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);
            var posts = response.Content.ReadAsAsync<List<Post>>().Result;
            
            Assert.IsTrue(posts.Count > 0);
        }

        /// <summary>
        /// Get post by Id
        /// </summary>
        [TestMethod]
        public void GetPostsById_Test()
        {
            var fullUrl = url + "posts/20";
            var response = client.GetAsync(fullUrl).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);
            var post = response.Content.ReadAsAsync<Post>().Result;
            
            Assert.IsTrue(post.Title.Equals("doloribus ad provident suscipit at"));
        }

        /// <summary>
        /// Post new post
        /// </summary>
        [TestMethod]
        public void PostPost_Test()
        {
            var post = new Post(23, 201, "Test post", "This a test post");
            var fullUrl = url + "posts";
            var response = client.PostAsJsonAsync<Post>(fullUrl, post).Result;
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            client.Dispose();
            client = null;
        }
    }
}
