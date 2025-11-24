using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBankSeleniumTests
{
    public class LoginPage
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public ChromeDriver ChrDriver { get; set; }

        public LoginPage(ChromeDriver driver, string username, string password)
        {
            Username = username;
            Password = password;
            ChrDriver = driver;
        }

        public IWebElement login()
        {
            var username = ChrDriver.FindElement(By.Name("username"));
            var pwd = ChrDriver.FindElement(By.Name("password"));

            username.Clear();
            username.SendKeys(Username);
            pwd.Clear();
            pwd.SendKeys(Password);
            
            ChrDriver.FindElement(By.XPath("//input[@value='Log In']")).Click();

            return ChrDriver.FindElement(By.Id("overviewAccountsApp"));            
        }

    }
}
