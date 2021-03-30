using System;
using System.Diagnostics;
using System.Net.Http;

namespace AutomationChallenge.Helper
{
    public class HttpClientHelper : Hooks
    {
        private readonly HttpClient httpClient;
        public HttpClientHelper()
        {
            // Creating object of HttpClient
            httpClient = new HttpClient();
        }

        /// <summary>
        /// Get APi call to get with codes
        /// </summary>
        /// <param name="stopWatch"></param>
        /// <param name="code"></param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage Get(Stopwatch stopWatch, string code)
        {

            try
            {   // Reading the apiurl from configuration file
                string apiUrl = GetConfiguration()["apiurl"] + code;
                stopWatch.Start();

                // GetAsync call to get result based on code
                var result = httpClient.GetAsync(apiUrl).GetAwaiter().GetResult();
                stopWatch.Stop();

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
