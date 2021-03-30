using AutomationChallenge.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;

namespace AutomationChallenge.Pages.MapNavigation
{
    public class MapPage
    {
        private readonly IWebDriver driver;
        public MapPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //locate the Zoom link
        public IWebElement ZoomOut => this.driver.FindElement(By.XPath("//button[@id='widget-zoom-out']"));

        //locate the distance element on map
        public IWebElement Distance => this.driver.FindElement(By.XPath("//button[@class='widget-scale noselect']/label"));

        /// <summary>
        /// Clicks the Zoom out link on map
        /// </summary>
        /// <returns>int</returns>
        public int MapZoomOut()
        {
            try
            {
                ExplictWait(this.driver);
                int distance = 0;
                while (distance < Constants.Distance)
                {
                    ZoomOut.Click();
                    this.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
                    distance = int.Parse(Regex.Match(Distance.Text, @"\d+").Value);

                    
                }
                return distance;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// applies explict wait
        /// </summary>
        private IWebElement ExplictWait(IWebDriver webdriver)
        {
            try
            {
                var wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(10));
                return wait.Until(driver => driver.FindElement(By.XPath("//button[@id='widget-zoom-out']")));
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
