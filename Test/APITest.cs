using NUnit.Framework;
using RestSharp;
using System.Net;

namespace RestSharpAPITesting
{
    public class APITest
    {
        
        [Test]
        [TestCase("data.json")]
        public void CreateUser(string jsonString)
        {
            RestAPIHelper<CreateUser> restApi = new RestAPIHelper<CreateUser>();
            RestClient restUrl = restApi.SetUrl("api/users");
            RestRequest restRequest = restApi.CreatePostRequest(jsonString);
            IRestResponse response = restApi.GetResponse(restUrl, restRequest);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            CreateUser content = restApi.GetContent<CreateUser>(response);
            Assert.AreEqual("morpheus", content.name);
            Assert.AreEqual("leader", content.job);
        }

        [Test]
        [TestCase("Janet", "Weaver", "janet.weaver@reqres.in")]
        public void VerifyUserName(string firstName, string lastName, string email)
        {
            RestAPIHelper<User> restApi = new RestAPIHelper<User>();
            RestClient restUrl = restApi.SetUrl("data/2.5/weather");
            RestRequest request = restApi.CreateGetRequest();
            request.AddParameter("q", "Sofia,BG");
            request.AddParameter("APPID", "805b6c110cd131902e5d7a2f95b433f6");
            IRestResponse response = restApi.GetResponse(restUrl, request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            User content = restApi.GetContent<User>(response);
            Assert.AreEqual(firstName, content.data.first_name);
            Assert.AreEqual(lastName, content.data.last_name);
            Assert.AreEqual(email, content.data.email);
        }
    }
}
