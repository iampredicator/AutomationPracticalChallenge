using AutomationChallenge.Base;
using AutomationChallenge.Helper;
using AutomationChallenge.Pages.SearchResult;
using AutomationChallenge.Webpages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace AutomationChallenge.Tests
{
    [TestFixture]
    [Parallelizable]
    public class BookTest : Hooks
    {
        private IWebDriver wdriver;
        private HomePage homePage;

        public BookTest()
        {
            this.wdriver = webDriver;
        }
        
        /// <summary>
        /// Searches text and clicks onBook link
        /// </summary>
        [Test]
        public void SearchBookTextClickBookResult()
        {
            try
            {
                
                // Initialize the page by calling its reference
                homePage = new HomePage(this.wdriver);

                ExcelLib.PopulateInCollection(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data.xlsx"));

                string text = ExcelLib.ReadData(1, Constants.column1);
                string linkName = ExcelLib.ReadData(1, Constants.column2);

                SearchResultPage resultPage = homePage.SearchTextInGoogleSearchBar(text);
                homePage.SearchBoxName.SendKeys(Keys.Enter);
               
                // Verifying if pagesource contains the searched text
                Assert.That(this.wdriver.PageSource.Contains(text), Is.EqualTo(true),
                                                            "pagesource does not contant" + text);
                resultPage.ClickElement(linkName,Constants.BookResultNo);
                
            }
            
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
