using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ICEWebSiteTestAutomationBase;
using ICEWebSiteTestAutomationBase.Domain;
using ICEWebSiteTestAutomationBase.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TheICEWebSiteTests
{
    [TestClass]
    public class TestLoginForOrderCancelUserLogout : BaseTest
    {
        
        [TestMethod]
        public void TestOrderCancel_UserLogoutLogin()
        {

            User user=new User("Lrobinson_prod","Starts123");
            OrderCancelUserLogoutPage orderCancelUserLogoutPage = TheIceHomePage.DoLoginForOrderCancelUserLogout(user);
            
            Assert.IsTrue(orderCancelUserLogoutPage.IsPageLoaded(),"orderCancelUserLogoutPage Is not Loaded");

        }


 

    }
}