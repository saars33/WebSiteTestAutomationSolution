using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
