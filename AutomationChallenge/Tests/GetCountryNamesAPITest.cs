using AutomationChallenge.Helper;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Diagnostics;
using System.Net;

namespace AutomationChallenge.Tests
{
    public class GetCountryNamesAPITest
    {
        private readonly HttpClientHelper httpClientHelper;
        public GetCountryNamesAPITest()
        {
            // creating object of HttpClientHelper
            httpClientHelper = new HttpClientHelper();
        }

        /// <summary>
        /// Getting countryname based on given codes
        /// </summary>
        [Test]
        [Category("API")]
        public void GetCountryName_API()
        {
            try
            {
                foreach (var code in Constants.zipCodes)
                {
                    // creating object of StopWatch
                    var stopWatch = new Stopwatch();

                    var response = httpClientHelper.Get(stopWatch, code);
                    JToken token = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                    string country = token.SelectToken("country").ToString();

                    // Verifying if data is returned is as expected
                    Assert.AreEqual(token.Next, null);
                    Assert.AreEqual(Constants.CountryName, country);
                    System.Console.WriteLine(country);
                    Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
                }
            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
