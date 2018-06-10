using System;
using Newtonsoft.Json;
using RestSharp;

namespace Study.Auth0.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            const string authority = "https://stylehopper.eu.auth0.com/oauth/token";
            const string apiIdentifier = "https://quickstarts/api";
            var clientId = Environment.GetEnvironmentVariable("STUDY_AUTH0_CLIENT_CLIENT_ID");
            var clientSecret = Environment.GetEnvironmentVariable("STUDY_AUTH0_CLIENT_CLIENT_SECRET");

            var client0 = new RestClient(authority);
            var request0 = new RestRequest(Method.POST);
            request0.AddHeader("content-type", "application/json");
            request0.AddParameter("application/json", "{\"grant_type\":\"client_credentials\",\"client_id\": \"" + clientId + "\",\"client_secret\": \"" 
                                                      + clientSecret + "\",\"audience\": \"" + apiIdentifier + "\"}", ParameterType.RequestBody);
            IRestResponse response1 = client0.Execute(request0);
            var resp1 = JsonConvert.DeserializeObject<Auth0Response>(response1.Content);

            Console.WriteLine("Press any key to send a request. Press ESC to exit...");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                var client1 = new RestClient("http://localhost:3010/api/private");
                var request1 = new RestRequest(Method.GET);
                request1.AddHeader("authorization", $"Bearer {resp1.AccessToken}");
                IRestResponse response = client1.Execute(request1);
                Console.WriteLine($"Response from /private: ${response.Content}");

                var client2 = new RestClient("http://localhost:3010/api/private-scoped");
                var request2 = new RestRequest(Method.GET);
                request2.AddHeader("authorization", $"Bearer {resp1.AccessToken}");
                IRestResponse response2 = client2.Execute(request1);
                Console.WriteLine($"Response from /private-scoped: {response2.Content}");
            }

            Console.ReadKey(true);
        }
    }
}
