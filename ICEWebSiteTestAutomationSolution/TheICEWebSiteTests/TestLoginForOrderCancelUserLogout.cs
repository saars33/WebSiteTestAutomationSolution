using ICEWebSiteTestAutomationBase.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheICEWebSiteTests
{
    [TestClass]
    public class TestLoginForOrderCancelUserLogout : BaseTest
    {
        [TestMethod]
        public void TestOrderCancel_UserLogoutLogin()
        {
            var user = new User("Lrobinson_prod", "Starts123");
            var orderCancelUserLogoutPage = TheIceHomePage.DoLoginForOrderCancelUserLogout(user);

            Assert.IsTrue(orderCancelUserLogoutPage.IsPageLoaded(), "orderCancelUserLogoutPage Is not Loaded");
        }
    }
}