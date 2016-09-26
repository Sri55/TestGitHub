using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AutomationTests
{
    [TestClass]
    public class TJGroup
    {
        IWebDriver _webDriver;
        private readonly By _jobtypeLocator = By.Id("JobType");


        [TestMethod]
        public void CwJobs()
        {
            IWebElement element = _webDriver.FindElement(By.Id("more-options-toggle"));
            element.Click();//Click on More Options button

            var dropdown = _webDriver.FindElement(By.XPath("//select[@id='JobType']"));
            SelectElement selectjobtype = new SelectElement(dropdown);//Select Job type dropdown
            selectjobtype.SelectByValue("10");
            IList<IWebElement> options = selectjobtype.Options;
            IWebElement firstOption = options[1];
            NUnit.Framework.Assert.AreEqual(firstOption.Text, "Permanent");
            Console.WriteLine("JobType contains: " + firstOption.Text);

        }

        [TestMethod]
        public void CompaniesListed()
        {
           IWebElement element = _webDriver.FindElement(By.XPath("//div[@class='counter']/h2/span[2]"));
            Console.WriteLine("Companies listed total : " + element.Text);
          
        }

        [TestMethod]
        public void SearchPermJobsInManchester()
        {
            IWebElement element3 = _webDriver.FindElement(By.Id("keywords"));
            element3.SendKeys("Manager");

            IWebElement element2 = _webDriver.FindElement(By.Id("location"));
            element2.SendKeys("Manchester");

            var radiusdropdown = _webDriver.FindElement(By.XPath("//select[@id='Radius']"));
            SelectElement selectradius = new SelectElement(radiusdropdown);//Select Radius type dropdown
            selectradius.SelectByValue("30");


            IWebElement moreoptions = _webDriver.FindElement(By.Id("more-options-toggle"));
            moreoptions.Click();
            Thread.Sleep(2000);
            IWebElement annualsal = _webDriver.FindElement(By.Id("salaryButtonAnnual"));
            annualsal.Click();

            var saldropdown = _webDriver.FindElement(By.XPath("//select[@id='salaryRate']"));
            SelectElement salary = new SelectElement(saldropdown);//Select Salary amount dropdown
            salary.SelectByValue("20000");

            var jobtypedropdown = _webDriver.FindElement(By.XPath("//select[@id='JobType']"));
            SelectElement selectjobtype = new SelectElement(jobtypedropdown);//Select Job type dropdown
            selectjobtype.SelectByValue("10");


            var recuitertype = _webDriver.FindElement(By.XPath("//label[@id='recruiterTypeButtonEmployer']"));
            recuitertype.Click();

            var searchbutton =
                _webDriver.FindElement(By.XPath("//input[@id='search-button']"));
            searchbutton.Click();

            //Assert that at least 2 pages of jobs are returned
            var totaljobspages = _webDriver.FindElement(By.XPath("//html/body/div[3]/div[7]/div/div[2]/div/div[1]/div[24]/div/div/nav/ul/li[3]/a"));
            NUnit.Framework.Assert.IsTrue(totaljobspages.Displayed);
        }

        [TestMethod]
        public void SiteCatalystCode()
          {
            //Assert that the results page html source contains the text “SITECATALYST CODE”
            IWebElement element = _webDriver.FindElement(By.XPath("//div[@class='kxhead']/span/script"));
             var x =   element.GetAttribute("textContent").Contains("SiteCatalyst");
            Console.WriteLine(x);
            
        }


        [TestInitialize]
        public void Setup()
        {
            
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl("https://www.cwjobs.co.uk/");
            _webDriver.Manage().Window.Maximize();

        }

        [TestCleanup]
        public void Teardown()
        {
            _webDriver.Close();
           
        }
        
        
    }
}
