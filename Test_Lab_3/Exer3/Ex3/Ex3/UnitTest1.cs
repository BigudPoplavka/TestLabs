using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Collections.Generic;

namespace Ex3
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver webDriver;
        IWebElement webElement;
        [SetUp]
        public void Setup()
        {

        }
        [Test, Order(0)]
        public void IsURLOfPageRegister()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("http://127.0.0.1:8000/register");
            string expectedURL = "http://127.0.0.1:8000/register";
            NUnit.Framework.Assert.AreEqual(expectedURL, webDriver.Url);
        }
        [Test, Order(1)]
        public void CheckExistFieldName()
        {
            NUnit.Framework.Assert.AreEqual(webDriver.FindElements(By.Name("name")).Count, 1);
        }
        [Test, Order(2)]
        public void CheckExistFieldSurname()
        {
            NUnit.Framework.Assert.AreEqual(webDriver.FindElements(By.Name("second_name")).Count, 1);
        }
        [Test, Order(3)]
        public void CheckExistFieldFatherName()
        {
            NUnit.Framework.Assert.AreEqual(webDriver.FindElements(By.Name("father_name")).Count, 1);
        }
        [Test, Order(4)]
        public void CheckExistFieldFatherPassword()
        {
            NUnit.Framework.Assert.AreEqual(webDriver.FindElements(By.Name("password_confirmation")).Count, 1);
        }
        [Test, Order(5)]
        public void insertDataIntoFieldName()
        {
            webElement = webDriver.FindElement(By.Name("name"));
            webElement.SendKeys("Богдан");
            string expected_text = "Богдан";
            NUnit.Framework.Assert.AreEqual(expected_text, webElement.GetAttribute("value"));
        }
        [Test, Order(6)]
        public void insertDataIntoFieldSecName()
        {
            webElement = webDriver.FindElement(By.Name("second_name"));
            webElement.SendKeys("Павленко");
            string expected_text = "Павленко";
            NUnit.Framework.Assert.AreEqual(expected_text, webElement.GetAttribute("value"));
        }
        [Test, Order(7)]
        public void insertDataIntoFieldFatherName()
        {
            webElement = webDriver.FindElement(By.Name("father_name"));
            webElement.SendKeys("Викторович");
            string expected_text = "Викторович";
            NUnit.Framework.Assert.AreEqual(expected_text, webElement.GetAttribute("value"));
        }
        [Test, Order(8)]
        public void insertDataIntoFieldConfirmPassw()
        {
            webElement = webDriver.FindElement(By.Name("password_confirmation"));
            webElement.SendKeys("11111111");
            string expected_text = "11111111";
            NUnit.Framework.Assert.AreEqual(expected_text, webElement.GetAttribute("value"));
        }
        [Test, Order(9)]
        public void ClickRegisterButton()
        {
            webElement = webDriver.FindElement(By.XPath("//div/div[3]"));
            webElement.Click();

            webDriver.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(7);

            var expectedPanel = webDriver.FindElement(By.ClassName("alert alert-danger alert-dismissible mt-4"));
            var roleValue = expectedPanel.GetAttribute("role");
            string expectedRole = "alert";
            NUnit.Framework.Assert.AreEqual(expectedRole, roleValue);
        }

    }
}
