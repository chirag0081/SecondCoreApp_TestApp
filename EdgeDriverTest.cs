using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Diagnostics;

namespace EdgeDriverTest1
{
    [TestClass]
    public class EdgeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.


        private ChromeDriver _driver;
        //private EdgeDriver _driver;
        WebDriverWait wait;
        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            // Initialize edge driver 
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
            };
            //_driver = new EdgeDriver(options);
            _driver = new ChromeDriver(".");
            wait = new WebDriverWait(_driver, new System.TimeSpan(0, 0, 10));
        }

        [TestMethod]
        public void TestMethod_02()
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
            
            System.Threading.Thread.Sleep(1000);

            IList<IWebElement> webElementsLinks = _driver.FindElementsByClassName("nav-link");
            Assert.AreEqual(3, webElementsLinks.Count);
            Assert.AreEqual("List", webElementsLinks[0].Text);
            Assert.AreEqual("Create", webElementsLinks[1].Text);
            System.Threading.Thread.Sleep(1000);
            Assert.AreEqual("Logout", webElementsLinks[2].Text);
            System.Threading.Thread.Sleep(1000);

        }

        [TestMethod]
       
        public void TestMethod_01()
        {
            // Replace with your own test logic
            _driver.Url = "http://localhost:1001/";
            _driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(1000);
            Assert.AreEqual("ClientApp", _driver.Title);
            
        }



        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Close();
            _driver.Quit();
            System.Threading.Thread.Sleep(500);
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }
           
        }
    }
}
