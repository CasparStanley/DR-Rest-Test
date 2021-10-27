using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace DR_Rest_Test
{
    [TestClass]
    public class UnitTest1
    {
        static string DriverDirectory = "C:\\webDrivers";
        static string URL = "file:///C:/Users/pointvoucher/Documents/_ZEALAND/3.%20Semester/Program/REST/DR-Rest-Website/index.html";
        //static IWebDriver driver = new ChromeDriver(DriverDirectory);
        static IWebDriver driver = new FirefoxDriver(DriverDirectory);
        static IWebElement getAllButtonElement;
        static IWebElement getIdInputFeild;
        static IWebElement getByIdButton;

        static IWebElement resultElement1;
        static IWebElement resultElement2;

        [ClassInitialize]
        public static void TestClassSetup(TestContext context)
        {
            driver.Navigate().GoToUrl(URL);
            getAllButtonElement = driver.FindElement(By.Id("getAll"));
            getByIdButton = driver.FindElement(By.Id("getById"));
            resultElement1 = driver.FindElement(By.Id("getResult1"));
            resultElement2 = driver.FindElement(By.Id("getResult2"));
            getIdInputFeild = driver.FindElement(By.Id("recordInputId"));
            //clearElement = driver.FindElement(By.Id("clear"));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            //clearElement.Click();
        }

        [TestMethod]
        public void GetAllTest()
        {
            getAllButtonElement.Click();

            Assert.IsNotNull(resultElement1.Text);
        }

        [TestMethod]
        public void GetByID()
        {
            // MEGET VIGTIGT AT CLEAR FØRST HVIS DIN FUCKINGF INPUTFELDT HAR EN DEFAULT VÆRDI
            getIdInputFeild.Clear();
            getIdInputFeild.SendKeys("3");

            getByIdButton.Click();

            Assert.IsTrue(resultElement2.Text.Contains("Hello"));
        }

        [ClassCleanup]
        public static void TestTearDown()
        {
            driver.Quit();
        }
    }
}
