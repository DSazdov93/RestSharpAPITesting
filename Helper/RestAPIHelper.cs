using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;

namespace RestSharpAPITesting
{
    public class RestAPIHelper<T>
    {
        public RestClient _restClient;
        public RestRequest _restRequest;
        public string _baseUrl = "https://reqres.in/";

        public RestClient SetUrl(string resourceUrl)
        {
            string url = Path.Combine(_baseUrl, resourceUrl);
            _restClient = new RestClient(url);
            return _restClient;
        }

        public RestRequest CreateGetRequest()
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddHeader("Accept", "application/json");
            return _restRequest;
        }

        public RestRequest CreatePostRequest(string jsonFileName)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.AddParameter("application/json", ReadJsonFile(jsonFileName), ParameterType.RequestBody);
            return _restRequest;
        }

        private string ReadJsonFile(string jsonFileName)
        {
            string jsonFilePath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\" + jsonFileName;
            string jsonData = File.ReadAllText(jsonFilePath);
            return jsonData;
        }

        public RestRequest CreateDeleteRequest()
        {
            _restRequest = new RestRequest(Method.DELETE);
            _restRequest.AddHeader("Accept", "application/json");
            return _restRequest;
        }

        public IRestResponse GetResponse(RestClient restClient, RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            string content = response.Content;
            DTO deseiralizeObject = JsonConvert.DeserializeObject<DTO>(content);
            return deseiralizeObject;
        }
    }
}
