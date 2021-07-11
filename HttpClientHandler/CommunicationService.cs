using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebApplication1
{
    public class CommunicationService
    {
        private static HttpClient Client = new HttpClient();
        private readonly IHttpClientFactory _clientFactory;
        public CommunicationService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public CommunicationService()
        {

        }
        public static string CallParticipantFI(string participantUrl, string xmlData)
        {
            Uri uri = new Uri(participantUrl);
            string responseResult = "";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage result = client.PostAsJsonAsync(uri, xmlData).Result;
                responseResult = result.Content.ReadAsStringAsync().Result;
            }
            return responseResult;
        }

        public async Task<string> CallParticipantFIUsingStaticHttpClientInstance(string participantUrl, string xmlData)
        {
            Uri uri = new Uri(participantUrl);
            HttpResponseMessage result = await Client.PostAsJsonAsync(uri, xmlData);
            string responseResult = result.Content.ReadAsStringAsync().Result;
            return responseResult;
        }

        public static string CallParticipantFIUsingStaticHttpClientWithoutAsync(string participantUrl, string xmlData)
        {
            Uri uri = new Uri(participantUrl);
            string responseResult = "";
            HttpResponseMessage result = Client.PostAsJsonAsync(uri, xmlData).Result;
            responseResult = result.Content.ReadAsStringAsync().Result;
            return responseResult;
        }

        public async Task<string> CallBaseInsertUsingHttpClientFactory(string participantUrl, string xmlData)
        {
            Uri uri = new Uri(participantUrl);
            HttpClient client = _clientFactory.CreateClient();
            HttpResponseMessage result = await client.PostAsJsonAsync(uri, xmlData);
            string responseResult = result.Content.ReadAsStringAsync().Result;
            return responseResult;
        }

    }
}
