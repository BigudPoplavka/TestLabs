using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task2Lab3
{
    class Program
    {
        static readonly IWebDriver _driver = new ChromeDriver(); // инициализация движка хром драйвера
        static void Main(string[] args)
        {
            try
            {
                _driver.Manage().Window.Maximize(); // открываем браузер на весь экран
                const string google = "https://www.google.com/";
                _driver.Navigate().GoToUrl(google); // говорим движку перейти по ссылке в гугл
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input")));
                IWebElement SearchBar = _driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"));
                SearchBar.SendKeys("unit testing");
                SearchBar.SendKeys(Keys.Enter);
                wait.Until(d=> d.FindElement(By.XPath("//*[@id=\"rso\"]/div[3]/div[2]/div/div[1]/a/h3")));
                _driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[3]/div[2]/div/div[1]/a/h3")).Click();
                wait.Until(d => d.FindElement(By.XPath(("//*[@id=\"searchInput\"]"))));
                IWebElement SearchBarWiki = _driver.FindElement(By.XPath("//*[@id=\"searchInput\"]"));
                SearchBarWiki.SendKeys("NUnit");
                SearchBarWiki.SendKeys(Keys.Enter);
                wait.Until(d => d.FindElement(By.XPath("/html/body/div[3]/div[3]/div[4]/div[3]/ul/li[1]/div[1]/a/span")));
                IWebElement LinkToNUnitWiki = _driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[4]/div[3]/ul/li[1]/div[1]/a/span"));
                LinkToNUnitWiki.Click();
                //wait.Until(ExpectedConditions.ElementExists(By.ClassName("interlanguage-link-target")));
                wait.Until(d => d.FindElement(By.ClassName("interlanguage-link-target")));
                var languages = _driver.FindElements(By.ClassName("interlanguage-link-target"));
                for (int i = 0; i < languages.Count; i++)
                {
                    if (languages[i].Text == "Русский")
                    {
                        Console.Clear();
                        Console.WriteLine("Русский язык есть!");
                        break;
                    }
                }
                Console.ReadKey();
                _driver.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
