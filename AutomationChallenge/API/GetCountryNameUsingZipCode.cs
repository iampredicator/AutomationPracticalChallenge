using System;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace AutomationChallenge
{
    
    public class GetCountryNameUsingZipCode : Hooks
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;
        private HttpResponseMessage response;
        private string result;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCountryNameUsingZipCode"/> class.
        /// </summary>
        public GetCountryNameUsingZipCode()
        {
            // creating object of HttpClientHelper
            httpClient = new HttpClient();
            apiUrl = GetConfiguration()["apiurl"];
        }

        /// <summary>
        /// Execute Get ZipCode API
        /// </summary>
        /// <param name="code"></param>
        public void ExecuteGetCountryAPIAsync(string code)
        {
            try
            {
                this.response = httpClient.GetAsync(apiUrl + code).Result;
                this.result = this.response.Content.ReadAsStringAsync().Result;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verify Status code
        /// </summary>
        /// <param name="country"></param>
        /// <param name="statusCode"></param>
        public void VerifyStatusAndCountryCode(string statusCode, string country = null)
        {
            try
            {
                if (!(this.response.StatusCode.ToString().Equals(statusCode)))
                {
                    throw new Exception("Status code mismatch");
                }
                if (!string.IsNullOrEmpty(country) && !this.result.Contains(country))
                {
                    throw new Exception("Country details mismatch");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
