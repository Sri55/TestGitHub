using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        IWebDriver driver;
        private readonly By _topLinkLocator = By.CssSelector("div[class='hamburger__front']");


        [TestMethod]
        public void Valtechnews()
        {
            IWebElement newis = driver.FindElement(By.CssSelector("div[class='news-post__listing-header']"));
            Assert.AreEqual(true, newis.Displayed);
            Console.WriteLine("Valtech Latest News Displayed Successfully");
        }

        [TestMethod]
        public void ValtechTopLinks()
        {
            //Cases
            driver.FindElement(_topLinkLocator).Click();
            driver.FindElement(By.XPath("//a[@href='/cases/']")).Click();
            var t = driver.FindElement(By.XPath("//header[@class='page-header']/h1")).Text;
            Assert.AreEqual("Cases",t);
            Console.WriteLine("Cases Passed");

            //Services
            driver.FindElement(_topLinkLocator).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[@href='/services/']")).Click();
            Thread.Sleep(3000);
            var t2 = driver.FindElement(By.XPath("//header[@class='page-header article__heading']/h1")).Text;
            Assert.AreEqual("Services", t2);
            Console.WriteLine("Services Passed");

            //Jobs
            driver.FindElement(_topLinkLocator).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[@href='/jobs/']")).Click();
            Thread.Sleep(2000);
            var t3 = driver.FindElement(By.XPath("//div[@class='page-header']/h1")).Text;
            Assert.AreEqual("Jobs", t3);
            Console.WriteLine("Jobs Passed");

        }

        [TestMethod]
        public void ValtechContacts()
        {
            IWebElement Offices = driver.FindElement(By.XPath("//i[@data-icon='earth-contact']"));
             Offices.Click();
            IWebElement select = driver.FindElement(By.ClassName("contactbody"));
            IList<IWebElement> allOptions = select.FindElements(By.TagName("li"));
            foreach (IWebElement li in allOptions)
            {
              Console.WriteLine("Valtech Offices are in : " + li.Text);
               
            }
          
         }


        [TestInitialize]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.valtech.com/");
        }

        [TestCleanup]
        public void Cleanup()
        {
            //driver.Close();
            driver.Quit();
        }


    }


}
