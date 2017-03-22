using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICEWebSiteTestAutomationBase.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//todo: download the C# udemy courses
//TODO: implement base classes looking at the C# courses
//TODO: Create driver managers using selenium Java
//Todo: Refactor testcases with the new driver manager class
//Todo: Refactor testcases with the new driver manager class
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
        protected IWebDriver WebDriver;
        protected TheIceHomePage TheIceHomePage;
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

            ChromeDriverService chromeDriverService =
                            ChromeDriverService.CreateDefaultService(
                                @"C:\Users\Public\AutomationSpecificFolders\sel_resources_go_here");

            WebDriver = new ChromeDriver(chromeDriverService);


            TheIceHomePage = new TheIceHomePage(WebDriver);
            TheIceHomePage.Load();





        }

        [TestCleanup]
        public void TestCleanup()
        {
            //WebDriver.Quit();
        }


    }
}
