using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBankSeleniumTests
{
    public class Driver
    {
        private ChromeDriver _webDriver;

        public ChromeDriver TestChromeDriver {
            get;          
            set ; 
        }
        public Driver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized"); // Start maximized

            ChromeDriver _webDriver = new ChromeDriver();            
            _webDriver.Navigate().GoToUrl("https://parabank.parasoft.com/");
            _webDriver.Manage().Window.Maximize();

            TestChromeDriver = _webDriver;
        }

        
    }
}
