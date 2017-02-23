using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

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
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://ft.theice.com");
            //webDriver.Close();
            
            IWebElement loginWebElement = webDriver.FindElement(By.XPath("//div/ul[2]/li[1]/a"));
            loginWebElement.Click();

            //IWebElement selectAnOptionComboElement = webDriver.FindElement(By.XPath(".//*[@href='#Select an Option']"));
            IWebElement selectAnOptionComboElement = webDriver.FindElement(By.CssSelector(".selectbox.form-control.selectbox-long.selectbox-compact.selectbox-single"));
            selectAnOptionComboElement.Click();

            IWebElement loginSelectBoxWebElement = webDriver.FindElement(By.ClassName("selectbox-options"));
            IReadOnlyCollection<IWebElement> loginOptionsList = loginSelectBoxWebElement.FindElements(By.TagName("a"));
            
            foreach (var webElement in loginOptionsList)
            {
                //System.Diagnostics.Debug.WriteLine("the current text is >>" + webElement.Text);
                if (webElement.Text== "Trader Dashboard")
                {
                    webElement.Click();
                }
            }

        }

/*        [TestCleanup]
        public void MyScratchTestCleanup()
        {
            
        }*/

    }
}
