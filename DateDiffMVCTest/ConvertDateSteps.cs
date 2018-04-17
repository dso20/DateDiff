﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace DateDiffMVCTest
{
    [Binding]
    public class ConvertDateSteps
    {
        private IWebDriver _driver;
        private ConvertDatePage _converDatePage;

        public ConvertDateSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I enter a valid start date of (.*)/(.*)/(.*)")]
        public void GivenIEnterAValidStartDateOf(IWebDriver driver,string p0, string p1, string p2)
        {
            _driver = driver;
            _converDatePage = new ConvertDatePage(_driver);
            _converDatePage.EnterValidStart( p0, p1, p2);
        }

        [When(@"I submit")]
        public void WhenISubmit()
        {
            _converDatePage.Submit();
        }


        [Given(@"I enter a vaild end date of (.*)/(.*)/(.*)")]
        public void GivenIEnterAVaildEndDateOf(string day, string month, string year)
        {
           _converDatePage.EnterValidEnd(day,month,year);
        }

        [Then(@"I get back the difference between the dates (.*)")]
        public void ThenIGetBackTheDifferenceBetweentHeDates(string p0)
        {
            var result =_converDatePage.Difference();
            Assert.That(p0, Is.EqualTo(result));

        }

        [Then(@"I get error message back (.*)")]
        public void ThenIGetErrorMessageBack(string expected)
        {
            var result = _converDatePage.ErrorMessage();
            Assert.That(expected,Is.EqualTo(result));
        }


        [AfterScenario]
        public void TearDown()
        {
            _driver.Dispose();
        }

    }
}
