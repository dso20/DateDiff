using System;
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

        [Given(@"I enter a valid start date of (.*)/(.*)/(.*)")]
        public void GivenIEnterAValidStartDateOf(string p0, string p1, string p2)
        {
            _driver = new ChromeDriver(@"C:\Users\dowen\AppData\Local\Google\Chrome\Application\");
            _driver.Manage().Window.Maximize();

            _converDatePage = new ConvertDatePage(_driver);
            _converDatePage.EnterValidStart( p0, p1, p2);

        }

        [When(@"I submit")]
        public void WhenISubmit()
        {
            _converDatePage.Submit();
        }


        [Given(@"I enter a vaild end date of (.*)/(.*)/(.*)")]
        public void GivenIEnterAVaildEndDateOf(string p0, string p1, string p2)
        {
           _converDatePage.EnterValidEnd(p0,p1,p2);
        }

        [Then(@"I get back the difference betweent he dates (.*)")]
        public void ThenIGetBackTheDifferenceBetweentHeDates(string p0)
        {
            var result =_converDatePage.Difference();
            Assert.That(p0, Is.EqualTo(result));

        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.Dispose();
        }




    }
}
