using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
namespace DateDiffMVCTest
{
    class ConvertDatePage
    {
        private IWebDriver _driver;
        private const string PageUri = @"http://localhost:9237/Home/Index";

        public ConvertDatePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public ConvertDatePage()
        {
            _driver.Navigate().GoToUrl(PageUri);

          //  PageFactory.InitElements(_driver,this);
        }

        public void EnterValidStart(string day, string month, string year)
        {
            IWebElement dropDownValue = _driver.FindElement(By.Id("StartDate_Day"));
            dropDownValue.SendKeys(day);
            dropDownValue = _driver.FindElement(By.Id("StartDate_Month"));
            dropDownValue.SendKeys(month);
            dropDownValue = _driver.FindElement(By.Id("StartDate_Year"));
            dropDownValue.SendKeys(year);
        }

        public void EnterValidEnd(string day, string month, string year)
        {
            IWebElement dropDownValue = _driver.FindElement(By.Id("EndDate_Day"));
            dropDownValue.SendKeys(day);
            dropDownValue = _driver.FindElement(By.Id("EndDate_Month"));
            dropDownValue.SendKeys(month);
            dropDownValue = _driver.FindElement(By.Id("EndDate_Year"));
            dropDownValue.SendKeys(year);
        }
        //remove driveer param?
        public void Submit()
        {
            _driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")).Click();
        }

        public string Difference()
        {
            return _driver.FindElement(By.Id("result")).Text;
        }

        public string ErrorMessage()
        {
            return _driver.FindElement(By.CssSelector(".validation-summary-errors.text-danger ul li")).Text;

        }



    }
}
