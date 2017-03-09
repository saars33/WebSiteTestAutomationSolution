using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;


namespace TheICEWebSiteTests
{
    [TestClass]
    public class ScratchPadTests
    {
/*        [TestInitialize]
                        public void MyScratchTestInitializeeMethod()
                        {
                            
                            
                        }*/

        private static string _s3;
        [TestMethod]
        public void MyFirstScratchTestMethod()
        {
/*                        FirefoxDriverService ffDriverService =
                                                    FirefoxDriverService.CreateDefaultService(@"C:\Users\Public\AutomationSpecificFolders\sel_resources_go_here");*/
            //IWebDriver webDriver = new FirefoxDriver();

            FirefoxBinary firefoxBinary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
            IWebDriver webDriver = new FirefoxDriver(firefoxBinary, new FirefoxProfile());

            /*            ChromeDriverService chromeDriverService =
                            ChromeDriverService.CreateDefaultService(
                                @"C:\Users\Public\AutomationSpecificFolders\sel_resources_go_here");
                        IWebDriver webDriver = new ChromeDriver(chromeDriverService);*/

            webDriver.Navigate().GoToUrl("http://ft.theice.com");

            bool x=new WebDriverWait(webDriver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.TitleIs("ICE"));

            
            //webDriver.Close();
            IWebElement loginWebElement = null;
            try
            {
                loginWebElement = webDriver.FindElement(By.XPath("//div/ul[2]/li[1]/abcd"));
                
            }
            catch (Exception)
            {
                loginWebElement = webDriver.FindElement(By.XPath("//div/ul[2]/li[1]/a"));

            }
            loginWebElement.Click();

            /*            Actions actions = new Actions(webDriver);
                                                            actions.MoveToElement(loginWebElement);
                                                            actions.Perform();*/


            //IWebElement selectAnOptionComboElement = webDriver.FindElement(By.XPath(".//*[@href='#Select an Option']"));
            IWebElement selectAnOptionComboElement =
                webDriver.FindElement(
                    By.CssSelector(".selectbox.form-control.selectbox-long.selectbox-compact.selectbox-single"));
            selectAnOptionComboElement.Click();

            IWebElement loginSelectBoxWebElement = webDriver.FindElement(By.ClassName("selectbox-options"));
            IReadOnlyCollection<IWebElement> loginOptionsList = loginSelectBoxWebElement.FindElements(By.TagName("a"));

            //foreach (var webElement in loginOptionsList)
            for (int i = 0; i < loginOptionsList.Count; i++)
            {
                loginSelectBoxWebElement = webDriver.FindElement(By.ClassName("selectbox-options"));
                IWebElement webElement = loginSelectBoxWebElement.FindElements(By.TagName("a"))[i];
                string webElementText = webElement.Text;
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor) webDriver;
                javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                //webElement = webDriver.FindElement(By.LinkText(webElementText));


                webElement.Click();

                IReadOnlyCollection<IWebElement> userNameCollection =
                    webDriver.FindElements(By.XPath("//input[(@type='text') and (@placeholder='Username')]"));
                if (userNameCollection.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine(i + " >the current text is >>" + webElementText);
                    IWebElement userNameElement = userNameCollection.ElementAt(0);
                    userNameElement.Clear();
                    userNameElement.SendKeys("abcd");

                    IWebElement passwordElement = webDriver.FindElement(By.XPath("//input[@placeholder='Password']"));
                    passwordElement.Clear();
                    passwordElement.SendKeys("blahblah");
                }


                selectAnOptionComboElement.Click();
            }
            webDriver.Close();
        }

/*        [TestMethod]
        public void MySecondScratchTestMethod()
        {


            FirefoxBinary firefoxBinary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
            IWebDriver webDriver = new FirefoxDriver(firefoxBinary, new FirefoxProfile());
            webDriver.Navigate().GoToUrl("http://ft.theice.com");
            webDriver= new  FirefoxDriver(firefoxBinary, new FirefoxProfile());
            webDriver.Navigate().GoToUrl("http://www.msn.com");
            _s3 = webDriver.CurrentWindowHandle;
            webDriver = new FirefoxDriver(firefoxBinary, new FirefoxProfile());
            webDriver.Navigate().GoToUrl("http://www.yahoo.com");
            _s3 = webDriver.WindowHandles.First();
            //webDriver.SwitchTo().Window(s1);
            webDriver.SwitchTo().Window(_s3);

            System.Uri uri = new System.Uri("http://localhost:7055/hub");
            webDriver = new RemoteWebDriver(uri, DesiredCapabilities.Firefox());
            webDriver.SwitchTo().Window(_s3);
            webDriver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void MyThirdScratchTestMethod()
        {


            /*            FirefoxBinary firefoxBinary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
                        IWebDriver webDriver = new FirefoxDriver(firefoxBinary, new FirefoxProfile());#1#

            System.Uri uri = new System.Uri("http://localhost:7055/hub");
            IWebDriver webDriver=new RemoteWebDriver(uri,DesiredCapabilities.Firefox());
            webDriver.SwitchTo().Window(_s3);
            
            //IReadOnlyCollection<string> collection = webDriver.WindowHandles;
           

                System.Diagnostics.Debug.WriteLine(webDriver.Title);
        }*/
        /*        [TestCleanup]
                                public void MyScratchTestCleanup()
                                {

                                }*/
    }
}