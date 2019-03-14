using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumCore
{
    [TestClass]
    public class HomePageFeature
    {
        IWebDriver _driver;
        [TestMethod]
        public void ShouldBeAbleToLogin()
        {            
            //1. Start session
            _driver = new ChromeDriver();
            //2. Navigate
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            //3. Identify location of element
            var loginButtonLocator = By.ClassName("login-button");
            //4. Ensure browser is in correct state before acting
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(loginButtonLocator));
            //5. Take action on element
            var userNameField = _driver.FindElement(By.Id("user-name"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(loginButtonLocator);
            userNameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginButton.Click();
            //6. Record the result
            Assert.IsTrue(_driver.Url.Contains("inventory.html"));           
        }

        [TestCleanup]
        public void ClenUp()
        {
            //7. Quit session (close browser)
            _driver.Quit();
        }
    }
}
