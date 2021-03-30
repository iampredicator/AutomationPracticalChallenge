using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace AutomationChallenge
{
    [TestFixture]
    public class Hooks : Base.Base
    {
        public IWebDriver webDriver;
        private ScenarioContext context;
       
        public Hooks()
        {
            this.webDriver = driver;
            this.webDriver = InitializeDriver();
        }

        [SetUp]
        /// <summary>
        /// Initializes the webdriver
        /// </summary>
        /// <param name="browserName"></param>
        /// <returns>IWebDriver</returns>
        private IWebDriver InitializeDriver()
        {
            try
            {
                Dictionary<string, string> configurationDict = GetConfiguration();
                if (TestContext.CurrentContext.Test.Name.ToLower().Contains(configurationDict["apitest"].ToLower()))
                    return null;

                BrowserType brName;
                var browser = TestContext.Parameters.Get("browser");
               
                // Check browser name is read from configuration or CLI
                if (string.IsNullOrEmpty(browser))
                {
                    brName = (BrowserType)Enum.Parse(typeof(BrowserType), configurationDict["browser"], true);
                }
                else 
                {
                    browser.ToLower();
                    brName = (BrowserType)Enum.Parse(typeof(BrowserType), browser, true);
                }
                if (BrowserType.chrome == brName)
                    this.webDriver = new ChromeDriver();
                else if (BrowserType.firefox == brName)
                    webDriver = new FirefoxDriver();
                this.webDriver.Url = configurationDict["url"];
                this.webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                
                return webDriver;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Read the configuration xml file and stores data in Dictionary
        /// </summary>
        /// <returns>Dictionary<string, string></returns>
        protected Dictionary<string, string> GetConfiguration()
            {
                try
                {
                    Dictionary<string, string> attributDict = new Dictionary<string, string>();
                    XDocument xdoc = new XDocument();
                    xdoc = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configurations.xml"));

                    // Iterate Xdocument to store all attributes
                    foreach (XElement element in xdoc.Root.Nodes())
                    {
                        if (element.Name == "Configuration")
                            attributDict.Add(element.Attributes("attribute-id").First().Value, element.Value);
                    }
                    return attributDict;
                }

                catch (Exception)
                {

                    throw;
                }

            }

        /// <summary>
        /// closes the webdriver
        /// </summary>
        [TearDown]
        protected void CloseBrowser()
        {
            try
            {
                this.webDriver.Quit();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}
