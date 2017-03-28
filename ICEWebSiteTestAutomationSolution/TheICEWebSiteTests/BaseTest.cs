using ICEWebSiteTestAutomationBase.Pages;
using ICEWebSiteTestAutomationBase.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

//todo: Refactor the login methods to use enums
//todo: learn more about internal methods
//TODO: Create driver managers using selenium Java (partially done)
//TODO: implement base classes looking at the C# courses
//TODO: configuration and putting the driver.exe files within the project

//TODO: implement logging
//todo: extent reports
//todo: NUnit
//todo: crawler
//TODO: implement dump hardcoded data to excel and implement excel helpers
//todo: figure out how to reun multiple browsers
//todo: sauce labs integration

namespace TheICEWebSiteTests
{
    public class BaseTest
    {
        protected TheIceHomePage TheIceHomePage;
        protected IWebDriver WebDriver;

        [TestInitialize]
        public void TestInitializeMethod()
        {
            //the next steps will launch browser, navigate to the page and click the login button
            /*                        FirefoxDriverService ffDriverService =
                                                                            FirefoxDriverService.CreateDefaultService(@"C:\Users\Public\AutomationSpecificFolders\sel_resources_go_here");*/
            //webDriver = new FirefoxDriver();

            /*
                        var firefoxBinary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
                        _webDriver = new FirefoxDriver(firefoxBinary, new FirefoxProfile());
            */

            /*ChromeDriverService chromeDriverService =
                            ChromeDriverService.CreateDefaultService(
                                @"C:\Users\Public\AutomationSpecificFolders\sel_resources_go_here");*/

            WebDriver = Driver.Get();


            TheIceHomePage = new TheIceHomePage(WebDriver);
            TheIceHomePage.Load();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            WebDriver.Quit();
        }
    }
}