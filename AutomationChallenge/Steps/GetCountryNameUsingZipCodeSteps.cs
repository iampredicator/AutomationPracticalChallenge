using AutomationChallenge.Helper;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationChallenge.Steps
{
    [Binding]
    public class GetCountryNameUsingZipCodeSteps
    {
        private readonly ScenarioContext context;
        private readonly GetCountryNameUsingZipCode getCountryNameUsingZipCode;
        public GetCountryNameUsingZipCodeSteps(ScenarioContext injectedContext)
        {
            this.context = injectedContext;
            this.getCountryNameUsingZipCode = new GetCountryNameUsingZipCode();
        }
        [When(@"I try to get country name using invalid zipcodes '(.*)' while executing scenaio '(.*)'")]
        [When(@"I get country name using zipcodes '(.*)' while executing scenaio '(.*)'")]
        public void WhenIGetCountryNameUsingZipcodesWhileExecutingScenaio(string strCode, string scenarioName)
        {
            try
            {
                string zipCode = string.Empty;
                if (scenarioName != Constants.SpecFlowNULLReference)
                {
                    this.context["ScenarioName"] = scenarioName;
                }
                if (!string.IsNullOrEmpty(strCode))
                {
                    zipCode = strCode;
                }

                this.getCountryNameUsingZipCode.ExecuteGetCountryAPIAsync(zipCode);

            }
            catch (Exception ex)
            {
                Assert.Fail($"{ex.GetType().Name} : {ex.Message}");
            }

        }

        [Then(@"Country name '(.*)' should be returned with status '(.*)'\.")]
        public void ThenCountryNameUnitedStatesShouldBeReturnedWithStatus_(string country, string statusCode)
        {
            try
            {
                this.getCountryNameUsingZipCode.VerifyStatusAndCountryCode(statusCode, country);
            }
            catch (Exception ex)
            {

                Assert.Fail($"{ex.GetType().Name} : {ex.Message}");
            }
        }

        [Then(@"API should throw status code '(.*)'\.")]
        public void ThenAPIShouldThrowStatusCode_(string statusCode)
        {
            try
            {
                this.getCountryNameUsingZipCode.VerifyStatusAndCountryCode(statusCode,null);
            }
            catch (Exception ex)
            {

                Assert.Fail($"{ex.GetType().Name} : {ex.Message}");
            }
        }



    }
}
