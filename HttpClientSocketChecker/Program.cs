using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientSocketChecker
{
    class Program
    {
        //private static HttpClient Client = new HttpClient();
        private const string APIURL = "http://59.152.61.37:35005/BaseInsert";
        public static void Main(string[] args)
        {
            HttpClientUsingDisposal();
            //await HttpClientUsingStaticInstance();
        }

        private static void HttpClientUsingDisposal()
        {
            var uri = new Uri(APIURL);
            //var responseResult = "";
            //Console.WriteLine("Starting connections");
            for (int i = 0; i < 83; i++)
            {
                using (var client = new HttpClient())
                {
                    using var result = client.PostAsJsonAsync(uri, "Hello").Result;
                    //responseResult = result.Content.ReadAsStringAsync().Result;
                    //responseResult = responseResult.Replace("\\", "", StringComparison.CurrentCulture);
                    Console.WriteLine(result.StatusCode);
                }
            }
            Console.WriteLine("Connections done");
        }

        //private static async Task HttpClientUsingStaticInstance()
        //{
        //    var uri = new Uri(APIURL);
        //    Console.WriteLine("Starting connections");
        //    for (int i = 0; i < 10; i++)
        //    {
        //        var result = await Client.PostAsJsonAsync(uri, "Hello");
        //        Console.WriteLine(result.StatusCode);
        //    }
        //    Console.WriteLine("Connections done");
        //    Console.ReadLine();
        //}
    }
}
