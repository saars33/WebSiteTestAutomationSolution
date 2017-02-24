using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;


namespace TheICEWebSiteTests
{
    [TestClass]
    public class ScratchPadTests
    {
/*        [TestInitialize]
        public void MyScratchTestInitializeeMethod()
        {
            
            
        }*/

        [TestMethod]
        public void MyFirstScratchTestMethod()
        {
            FirefoxDriverService chromeDriverService =
                FirefoxDriverService.CreateDefaultService(@"C:\Users\ARVIND\selenium_resources_go_here\");
            IWebDriver webDriver = new FirefoxDriver(chromeDriverService);

/*
            ChromeDriverService chromeDriverService =
                ChromeDriverService.CreateDefaultService(@"C:\Users\ARVIND\selenium_resources_go_here\");
            IWebDriver webDriver = new ChromeDriver(chromeDriverService);
*/


            webDriver.Navigate().GoToUrl("http://ft.theice.com");
            //webDriver.Close();

            IWebElement loginWebElement = webDriver.FindElement(By.XPath("//div/ul[2]/li[1]/a"));
/*            Actions actions = new Actions(webDriver);
            actions.MoveToElement(loginWebElement);
            actions.Perform();*/
            loginWebElement.Click();

            //IWebElement selectAnOptionComboElement = webDriver.FindElement(By.XPath(".//*[@href='#Select an Option']"));
            IWebElement selectAnOptionComboElement =
                webDriver.FindElement(
                    By.CssSelector(".selectbox.form-control.selectbox-long.selectbox-compact.selectbox-single"));
            selectAnOptionComboElement.Click();

            IWebElement loginSelectBoxWebElement = webDriver.FindElement(By.ClassName("selectbox-options"));
            IReadOnlyCollection<IWebElement> loginOptionsList = loginSelectBoxWebElement.FindElements(By.TagName("a"));

            //foreach (var webElement in loginOptionsList)
            for (int i = 7; i < loginOptionsList.Count; i++)
            {
                //Thread.Sleep(1000);
                loginSelectBoxWebElement = webDriver.FindElement(By.ClassName("selectbox-options"));
                IWebElement webElement = loginSelectBoxWebElement.FindElements(By.TagName("a"))[i];
                string webElementText = webElement.Text;
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)webDriver;
                javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                //webElement = webDriver.FindElement(By.LinkText(webElementText));

                Thread.Sleep(2000);
                webElement.Click();

                //Thread.Sleep(new TimeSpan(0, 0, 1));

                IReadOnlyCollection<IWebElement> userNameCollection =
                    webDriver.FindElements(By.XPath("//input[(@type='text') and (@placeholder='Username')]"));
                if (userNameCollection.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine(i+ " >the current text is >>" + webElementText);
                    IWebElement userNameElement = userNameCollection.ElementAt(0);
                    userNameElement.Clear();
                    userNameElement.SendKeys("abcd");
                    
                    IWebElement passwordElement = webDriver.FindElement(By.XPath("//input[@placeholder='Password']"));
                    passwordElement.Clear();
                    passwordElement.SendKeys("blahblah");
                }

                //Thread.Sleep(2000);
                selectAnOptionComboElement.Click();
                

            }
            webDriver.Close();
        }

/*        [TestCleanup]
        public void MyScratchTestCleanup()
        {
            
        }*/
    }
}
