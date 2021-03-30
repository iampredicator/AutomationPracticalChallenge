using AutomationChallenge.Helper;
using AutomationChallenge.Pages.MapNavigation;
using AutomationChallenge.Pages.SearchResult;
using AutomationChallenge.Webpages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationChallenge.Tests
{
    [TestFixture]
    [Parallelizable]
    public class MapTest : Hooks
    {
        private IWebDriver wdriver;
        HomePage homePage;
        MapPage mapPage;

        public MapTest()
        {
            this.wdriver = webDriver;
        }

        /// <summary>
        /// Searches and click on Maps link
        /// </summary>
        [Test]

        public void SearchMapTextZoomInMap()
        {
            try
            {
                // Initialize the page by calling its reference
                homePage = new HomePage(this.wdriver);
                mapPage = new MapPage(this.wdriver);

                SearchResultPage resultPage = homePage.SearchTextInGoogleSearchBar("paravani lake");
                homePage.SearchBoxName.SendKeys(Keys.Enter);
                resultPage.ClickElement(Constants.MapsText);
                Assert.That(mapPage.MapZoomOut().Equals(Constants.Distance), Is.EqualTo(true), "distance is not equal to " + Constants.Distance);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
