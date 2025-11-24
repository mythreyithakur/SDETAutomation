using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBankSeleniumTests
{
    public class LoginPage
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public EdgeDriver brDriver { get; set; }

        public LoginPage(EdgeDriver driver, string username, string password)
        {
            Username = username;
            Password = password;
            brDriver = driver;
        }

        public IWebElement login()
        {
            var username = brDriver.FindElement(By.Name("username"));
            var pwd = brDriver.FindElement(By.Name("password"));

            username.Clear();
            username.SendKeys(Username);
            pwd.Clear();
            pwd.SendKeys(Password);
            
            brDriver.FindElement(By.XPath("//input[@value='Log In']")).Click();

            return brDriver.FindElement(By.Id("overviewAccountsApp"));            
        }

    }
}
