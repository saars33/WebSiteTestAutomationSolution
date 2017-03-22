using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ICEWebSiteTestAutomationBase.Pages
{
    public class OrderCancelUserLogoutPage : BasePage<OrderCancelUserLogoutPage>
    {
        private readonly IWebDriver _webDriver;
        private IWebElement _orderCancelUserLogoutLabelWebElement;

        private IWebElement OrderCancelUserLogoutLabelWebElement
        {
            get
            {
                return
                    _orderCancelUserLogoutLabelWebElement ?? (_orderCancelUserLogoutLabelWebElement =
                        _webDriver.FindElement(By.XPath("//h1[text()='Order Cancel / User Logout']")));
            }
            set { _orderCancelUserLogoutLabelWebElement = value; }
        }

        public OrderCancelUserLogoutPage(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }

        #region Overrides of LoadableComponent<OrderCancelUserLogoutPage>

        /// <inheritdoc />
        protected override void ExecuteLoad()
        {
            new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.TitleIs("ICE Logout"));

        }

        /// <inheritdoc />
        protected override bool EvaluateLoadedStatus()
        {

            return OrderCancelUserLogoutLabelWebElement.Displayed;

        }

        #endregion


    }
}