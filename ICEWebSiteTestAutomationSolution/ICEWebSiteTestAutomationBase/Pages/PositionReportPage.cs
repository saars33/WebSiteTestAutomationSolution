using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ICEWebSiteTestAutomationBase.Pages
{
    public class PositionReportPage : BasePage<PositionReportPage>
    {
        private IWebDriver _webDriver;
        private IWebElement _positionReportTitleWebElement;

        private IWebElement PositionReportTitleWebElement
        {
            get { return _positionReportTitleWebElement?? (_positionReportTitleWebElement=_webDriver.FindElement(By.XPath("//*[text()='POSITION REPORT']"))); }
            set { _positionReportTitleWebElement = value; }
        }

        public PositionReportPage(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }

        #region Overrides of LoadableComponent<PositionReportPage>

        /// <inheritdoc />
        protected override void ExecuteLoad()
        {
            new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.TitleIs("ICE: Position Report"));
        }

        /// <inheritdoc />
        protected override bool EvaluateLoadedStatus()
        {
            return PositionReportTitleWebElement.Displayed;
        }

        #endregion
    }
}