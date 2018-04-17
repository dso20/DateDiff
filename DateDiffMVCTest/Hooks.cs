using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace DateDiffMVCTest
{
    [Binding]
    class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        public IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Initialise()
        {
            if (_driver == null)
            {
                _driver = new ChromeDriver(@"C:\Users\dowen\AppData\Local\Google\Chrome\Application\");
                _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                _driver.Navigate().GoToUrl(@"http://localhost:9237/Home/Index");
                _driver.Manage().Window.Maximize();
            }
        }

        [AfterScenario]
        public void CleanUp()
        {
            if (_driver != null)
                _driver.Dispose();
        }
    }
}
