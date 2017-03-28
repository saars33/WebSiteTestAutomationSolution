using OpenQA.Selenium.Support.UI;

namespace ICEWebSiteTestAutomationBase.Pages
{
    public abstract class BasePage<T> : LoadableComponent<T> where T : LoadableComponent<T>
    {
        public bool IsPageLoaded()
        {
            return IsLoaded;
        }
    }
}