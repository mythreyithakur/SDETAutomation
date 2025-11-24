using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBankSeleniumTests
{
    public class Driver
    {
       
        public EdgeDriver TestBrowserDriver {
            get;          
            set ; 
        }
       

        public Driver()
        {

            //ChromeDriver _webDriver = new ChromeDriver();
            EdgeDriver _webDriver = new EdgeDriver();
            _webDriver.Navigate().GoToUrl("https://parabank.parasoft.com/");
            _webDriver.Manage().Window.Maximize();

            TestBrowserDriver = _webDriver;
        }

        
    }
}
