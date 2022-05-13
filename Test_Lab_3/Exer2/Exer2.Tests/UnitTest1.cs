using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Collections.Generic;
namespace Exer2.Tests
{
    public class Tests
    {
        ChromeDriver webDriver;
        IWebElement webElement;
        [SetUp]
        public void Setup()
        {

        }
        [Test, Order(0)]
        public void IsURLOfPageGoogleCom()
        {
            ChromeOptions chromeOptions = new ChromeOptions() { BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe" };
            webDriver = new ChromeDriver(chromeOptions);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://www.google.com/");
            string expectedURL = "https://www.google.com/";
            Assert.AreEqual(expectedURL, webDriver.Url);
        }
        [Test, Order(1)]
        public void CheckExistSearchBarOfGoogle()
        {
            Assert.AreEqual(webDriver.FindElements(By.Name("q")).Count, 1);
        }
        [Test, Order(2)]
        public void CheckTextUnitTestingInSearchBarOfGoogle()
        {
            //webDriver.Navigate().GoToUrl("https://www.google.com/");
            webElement = webDriver.FindElement(By.Name("q"));
            webElement.SendKeys("Unit testing");
            string expected_text_in_searchBar_Google = "Unit testing";
            Assert.AreEqual(expected_text_in_searchBar_Google, webElement.GetAttribute("value"));
        }
        [Test, Order(3)]
        public void CheckTextUnitTestingInSearchBarOfGoogleAfterSearching()
        {
            webElement.SendKeys(Keys.Enter);
            webElement = webDriver.FindElement(By.Name("q"));
            string expected_text_in_searchBar_Google = "Unit testing";
            Assert.AreEqual(expected_text_in_searchBar_Google, webElement.GetAttribute("value"));
        }
        [Test, Order(4)]
        public void CheckExistHREFUnitTestingWiki()
        {
            var links = webDriver.FindElements(By.TagName("a"));
            List<string> hrefs = new List<string>();
            foreach (var link in links)
            {
                hrefs.Add(link.GetAttribute("href"));
            }
            string expected_href = "https://en.wikipedia.org/wiki/Unit_testing";
            CollectionAssert.Contains(hrefs, expected_href);
        }
        [Test, Order(5)]
        public void CheckExistPageUnitTestingWiki()
        {
            webElement = webDriver.FindElement(By.XPath("//h3[contains(.,'Unit testing - Wikipedia')]"));
            webElement.Click();
            string expected_title_of_page = "Unit testing - Wikipedia";
            Assert.AreEqual(expected_title_of_page, webDriver.Title);
        }
        [Test, Order(6)]
        public void CheckExistSearchBarInPageOfWiki()
        {
            Assert.AreEqual(webDriver.FindElements(By.Name("search")).Count, 1);
        }
        [Test, Order(7)]
        public void CheckText_NUnit_SearchBarInPageOfWiki()
        {
            webElement = webDriver.FindElement(By.Name("search"));
            webElement.SendKeys("NUnit");
            string expected_text = "NUnit";
            Assert.AreEqual(expected_text, webElement.GetAttribute("value"));
        }
        [Test, Order(8)]
        public void CheckTitle_NUnit_Search_Wiki()
        {
            webElement.SendKeys(Keys.Enter);
            string expected_title_of_page = "NUnit - Search results - Wikipedia";
            Assert.AreEqual(expected_title_of_page, webDriver.Title);
        }
        [Test, Order(9)]
        public void CheckExistLinkToNUnitWiki_method1()
        {
            var links = webDriver.FindElements(By.TagName("a"));
            List<string> hrefs = new List<string>();
            foreach (var link in links)
            {
                hrefs.Add(link.GetAttribute("href"));
            }
            string expected_href = "https://en.wikipedia.org/wiki/NUnit";
            CollectionAssert.Contains(hrefs, expected_href);
        }
        [Test, Order(10)]
        public void CheckExistLinkToNUnitWiki_method2()
        {
            Assert.AreEqual(webDriver.FindElements(By.XPath("/html/body/div[3]/div[3]/div[4]/div[3]/ul/li[1]/div[1]/a/span")).Count, 1);
        }
        [Test, Order(11)]
        public void CheckTitle_NUnit_PageOfWiki()
        {
            webDriver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[4]/div[3]/ul/li[1]/div[1]/a/span")).Click();
            string expected_title = "NUnit - Wikipedia";
            Assert.AreEqual(expected_title, webDriver.Title);
        }
        [Test, Order(12)]
        public void CheckRussianLanguageOFArticleAboutNUnit()
        {
            var available_languages_from_the_page = webDriver.FindElements(By.ClassName("interlanguage-link-target"));
            List<string> name_languages = new List<string>();
            for (int i = 0; i < available_languages_from_the_page.Count; i++)
            {
                name_languages.Add(available_languages_from_the_page[i].Text);
            }
            string expected_language = "Русский";
            CollectionAssert.Contains(name_languages,expected_language);
            webDriver.Close();
            webDriver.Quit();
        }
    }
}