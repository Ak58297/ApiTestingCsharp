using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing.Get
{
    [TestClass]
    public class TestGetEndpoint
    {
        private readonly string url = "https://api.restful-api.dev/objects";
        private HttpClient? httpclient;
        private HttpResponseMessage? httpResponseMessage;
        string jsonResponse=string.Empty;

        [TestMethod]
        public void TestGetAllEndpoint()
        {
            //Create Http client object
            httpclient = new HttpClient();
            httpResponseMessage =  httpclient.GetAsync(url).Result;
       //     Console.WriteLine(httpResponseMessage+"\n");

            //Convert http response to stringJson
            jsonResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;
            Console.WriteLine(jsonResponse);

            // Format JSON in a pretty way
            string prettyJson = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(jsonResponse), Formatting.Indented);
            Console.WriteLine(prettyJson);

            //Get status code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine($"status code is {statusCode}");
            //Numerical representation
            Console.WriteLine($"status code is {(int)statusCode}");


            httpclient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndpointwithInvalidURL()
        {
            httpclient = new HttpClient();
            httpResponseMessage = httpclient.GetAsync(url+"random").Result;
            Console.WriteLine(httpResponseMessage+"\n");
            jsonResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;
            Console.WriteLine(jsonResponse);
            string prettyJson = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(jsonResponse), Formatting.Indented);
            Console.WriteLine(prettyJson);
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine($"status code is {statusCode}");
            Console.WriteLine($"status code is {(int)statusCode}");
            httpclient.Dispose();
        }
    }
}
