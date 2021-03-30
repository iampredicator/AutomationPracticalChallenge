using AutomationChallenge.Pages.SearchResult;
using OpenQA.Selenium;
using System;
namespace AutomationChallenge.Webpages
{
    public class HomePage
    {

        private readonly IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // locate google search bar box
        public IWebElement SearchBoxName => this.driver.FindElement(By.Name("q"));
       
        /// <summary>
        /// Searches text in Google search bar
        /// </summary>
        /// <param name="text"></param>
        /// <returns>SearchResultPage</returns>
        public SearchResultPage SearchTextInGoogleSearchBar(string text)
        {
            try
            {
                SearchBoxName.SendKeys(text);
                return new SearchResultPage(this.driver);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
