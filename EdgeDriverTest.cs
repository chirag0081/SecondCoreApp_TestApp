using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace EdgeDriverTest1
{
    [TestClass]
    public class EdgeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.


        private EdgeDriver _driver;
        WebDriverWait wait;
        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            // Initialize edge driver 
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
            };
            _driver = new EdgeDriver(options);
            wait = new WebDriverWait(_driver, new System.TimeSpan(0, 0, 10));
        }

        [TestMethod]
        public void Login()
        {
            _driver.Url = "http://localhost:1001/login";
            _driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(1000);
            IWebElement webElementEmail = _driver.FindElementById("Email");
            webElementEmail.SendKeys("abc@gmail.com");
            IWebElement webElementPassword = _driver.FindElementById("Password");
            webElementPassword.SendKeys("123456");

            IWebElement elementNext = _driver.FindElementByClassName("btn");
            elementNext.Click();
            
            System.Threading.Thread.Sleep(3000);

            IList<IWebElement> webElementsLinks = _driver.FindElementsByClassName("nav-link");
            Assert.AreEqual(3, webElementsLinks.Count);
            Assert.AreEqual("List", webElementsLinks[0].Text);
            Assert.AreEqual("Create", webElementsLinks[1].Text);
            Assert.AreEqual("Logout1 abc@gmail.com", webElementsLinks[2].Text);
            System.Threading.Thread.Sleep(3000);
        }

        [TestMethod]
        public void VerifyPageTitle()
        {
            // Replace with your own test logic
            _driver.Url = "http://localhost:1001";
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual("ClientApp", _driver.Title);
            System.Threading.Thread.Sleep(3000);
        }



        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
