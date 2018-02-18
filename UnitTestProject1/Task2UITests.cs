using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIOperationsTestTask
{
    [TestClass]
    public class Task2UITests
    {
        private MSLoginPage loginPage;

        /// <summary>
        /// Opens Microsoft login page
        /// </summary>
        [TestInitialize()]
        public void TestInitialize()
        {
            loginPage = new MSLoginPage();
            loginPage.NavigateTo();
            var valid = loginPage.IsValid; //Wait for the login page to be valid
        }

        /// <summary>
        /// Test enters user name, clicks Next, enters incorrct password and checks
        /// for password error
        /// </summary>
        [TestMethod]
        public void InvalidUserAttemptsToLogin_Test()
        {
            loginPage.DisplayLogin();
            loginPage.AzureADLogin("tester2018_1@hotmail.com", "");
            Assert.IsTrue(loginPage.IsPasswordError);
        }

        /// <summary>
        /// Stops Selenium Web Driver
        /// </summary>
        [TestCleanup()]
        public void TestCleanup()
        {
            loginPage.DriverHelper.Stop();
        }
    }
}
