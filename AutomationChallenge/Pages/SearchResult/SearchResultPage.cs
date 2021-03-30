using AutomationChallenge.Helper;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace AutomationChallenge.Pages.SearchResult
{
    public class SearchResultPage
    {
        private readonly IWebDriver driver;
        public SearchResultPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //locate the Books text link
        public IWebElement Books => this.driver.FindElement(By.LinkText("Books"));

        //locate the Maps text link
        IWebElement Maps => this.driver.FindElement(By.LinkText("Maps"));

        //locate the third element in books searched result list
        IList<IWebElement> links => this.driver.FindElements(By.XPath("//div[@class='Yr5TG']/div[2]/a"));

        /// <summary>
        /// Clicks the textlink for searched string
        /// </summary>
        /// <param name="linkText"></param>
        public void ClickElement(string linkText, int resultNo = 0)
        {
            try
            {
                if (linkText.ToLower() == Constants.BookTextLink)
                {
                    Books.Click();
                      ClickBookResultsLink(resultNo);

                }
                else if (linkText.ToLower() == Constants.MapsTextLink)
                    Maps.Click();
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        /// <summary>
        /// Clicks on given link from the result list
        /// </summary>
        /// <param name="resultNo"></param>
        private void ClickBookResultsLink(int resultNo)
        {
            try
            {
                string currentBookUrl = this.driver.Url;
                this.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
                try
                {
                    links[resultNo - 1].Click();
                }
                catch (TimeoutException ex)
                {

                    throw ex ;
                }
                
                string newBookUrl = this.driver.Url;

                if (currentBookUrl.Equals(newBookUrl))
                {
                    throw new Exception("book result is not clicked");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
