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

        public ConvertDatePage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver,this);
        }

        //better way to init using Pagefactory then assinging elelmets to fields
        // IWebElement _drop = _driver.FindElement(By.Id("StartDate_Day"));
        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'StartDate_Day')]")]
        private IWebElement _dropDownValue;

        //can then just use get set
        private string test
        {
            get => _dropDownValue.GetAttribute("value");
            set => _dropDownValue.SendKeys(value);
        }


        public void EnterValidStart(string day, string month, string year)
        {
            //better way to init using Pagefactory then assinging elelmets to fields
            // IWebElement _drop = _driver.FindElement(By.Id("StartDate_Day"));
            _dropDownValue.SendKeys(day);
            _dropDownValue = _driver.FindElement(By.Id("StartDate_Month"));
            _dropDownValue.SendKeys(month);
            _dropDownValue = _driver.FindElement(By.Id("StartDate_Year"));
            _dropDownValue.SendKeys(year);
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
