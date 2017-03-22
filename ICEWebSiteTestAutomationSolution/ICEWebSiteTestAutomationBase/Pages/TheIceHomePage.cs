using System;
using System.Collections.Generic;
using System.Diagnostics;
using ICEWebSiteTestAutomationBase.Domain;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ICEWebSiteTestAutomationBase.Pages
{
    public class TheIceHomePage : BasePage<TheIceHomePage> 
    {
        #region Fields
        private readonly IWebDriver _webDriver;
        private IWebElement _loginLinkWebElement;
        private IWebElement _selectAnOptionComboWebElement;
        private IWebElement _loginSelectBoxWebElement;
        private IReadOnlyCollection<IWebElement> _loginOptionWebElements;
        private IWebElement _userNameWebElement;
        private IWebElement _passwordWebElement;
        private IWebElement _loginButtonWebElement;

        #endregion

        #region Properties

        private IWebElement LoginLinkWebElement
        {
            get {
                return _loginLinkWebElement ?? (_loginLinkWebElement = _webDriver.FindElement(By.XPath("//div/ul[2]/li[1]/a")));
            }
            set { _loginLinkWebElement = value; }
        }

        private IWebElement SelectAnOptionComboWebElement
        {
            get { return _selectAnOptionComboWebElement ?? (_selectAnOptionComboWebElement = _webDriver.FindElement(
                By.CssSelector(".selectbox.form-control.selectbox-long.selectbox-compact.selectbox-single")) ); }
            set { _selectAnOptionComboWebElement = value; }
        }

        private IWebElement LoginSelectBoxWebElement
        {
            get { return _loginSelectBoxWebElement ?? (_webDriver.FindElement(By.ClassName("selectbox-options"))); }
            set { _loginSelectBoxWebElement = value; }
        }

        private IReadOnlyCollection<IWebElement> LoginOptionWebElements
        {
            get { return _loginOptionWebElements ?? LoginSelectBoxWebElement.FindElements(By.TagName("a"));  }
            set { _loginOptionWebElements = value; }
        }

        private IWebElement UserNameWebElement
        {
            get { return _userNameWebElement ?? _webDriver.FindElement(By.XPath("//input[(@type='text') and (@placeholder='Username')]")); }
            set { _userNameWebElement = value; }
        }

        private IWebElement PasswordWebElement
        {
            get { return _passwordWebElement ?? _webDriver.FindElement(By.XPath("//input[@placeholder='Password']")); }
            set { _passwordWebElement = value; }
        }

        private IWebElement LoginButtonWebElement
        {
            get { return _loginButtonWebElement ?? _webDriver.FindElement(By.XPath("//button[text()='Log In']")); }
            set { _loginButtonWebElement = value; }
        }

        #endregion



        #region Constructors

        public TheIceHomePage(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }

        #endregion


        private void SelectLoginMenuItem(string targetSelection)
        {
            foreach (var loginOptionElement in LoginOptionWebElements)
            {
                var curLoginOptionText = loginOptionElement.Text;
                if (curLoginOptionText.Equals(targetSelection, StringComparison.InvariantCultureIgnoreCase))
                {
                    var javaScriptExecutor = (IJavaScriptExecutor)_webDriver;
                    javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", loginOptionElement);
                    loginOptionElement.Click();
                    return;
                }
            }
            //throw new NotImplementedException();
        }

        private void DisplayLoginOptionsList()
        {
            
            LoginLinkWebElement.Click();
            SelectAnOptionComboWebElement.Click();
            
        }

        public OrderCancelUserLogoutPage DoLoginForOrderCancelUserLogout(User user)
        {

            DisplayLoginOptionsList();
            var targetSelection = "Order Cancel / User Logout";
            SelectLoginMenuItem(targetSelection);

            UserNameWebElement.Clear();
            UserNameWebElement.SendKeys(user.UserName);

            PasswordWebElement.Clear();
            PasswordWebElement.SendKeys(user.Password);

            LoginButtonWebElement.Click();

            OrderCancelUserLogoutPage orderCancelUserLogoutPage = new OrderCancelUserLogoutPage(_webDriver);

            orderCancelUserLogoutPage.Load();
            return orderCancelUserLogoutPage;

        }

        public PositionReportPage DoLoginForPositionReport(User user)
        {
            DisplayLoginOptionsList();
            var targetSelection = "Position Report";
            SelectLoginMenuItem(targetSelection);

            UserNameWebElement.Clear();
            UserNameWebElement.SendKeys(user.UserName);

            PasswordWebElement.Clear();
            PasswordWebElement.SendKeys(user.Password);

            LoginButtonWebElement.Click();
//            Debug.WriteLine(_webDriver.Title);
            PositionReportPage positionReportPage=new PositionReportPage(_webDriver);
            positionReportPage.Load();
            return positionReportPage;

        }

        #region Overrides of LoadableComponent<TheIceHomePage>

        /// <inheritdoc />
        protected override void ExecuteLoad()
        {
            _webDriver.Navigate().GoToUrl("http://ft.theice.com");
            new WebDriverWait(_webDriver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.TitleIs("ICE"));
        }

        /// <inheritdoc />
        protected override bool EvaluateLoadedStatus()
        {
            if (_webDriver.Title.Equals("ICE", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}