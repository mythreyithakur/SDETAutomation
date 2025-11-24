using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;


namespace ParaBankSeleniumTests
{
    public class CustomerPage
    {
        public EdgeDriver brwDriver { get; set; }
        public CustomerPage(EdgeDriver driver)
        {
            brwDriver = driver;
                 
        }

        public bool Register(CustomerDetails details)
        {
            brwDriver.FindElement(By.XPath("//a[@href= 'register.htm']")).Click();

            brwDriver.FindElement(By.Id("customer.firstName")).SendKeys(details.FirstName);
            brwDriver.FindElement(By.Id("customer.lastName")).SendKeys(details.LastName);
            brwDriver.FindElement(By.Id("customer.address.street")).SendKeys(details.Address);
            brwDriver.FindElement(By.Id("customer.address.city")).SendKeys(details.City);
            brwDriver.FindElement(By.Id("customer.address.state")).SendKeys(details.State);
            brwDriver.FindElement(By.Id("customer.address.zipCode")).SendKeys(details.ZipCode);
            brwDriver.FindElement(By.Id("customer.phoneNumber")).SendKeys(details.Phone);
            brwDriver.FindElement(By.Id("customer.ssn")).SendKeys(details.State);
            brwDriver.FindElement(By.Id("customer.username")).SendKeys(details.Username);
            brwDriver.FindElement(By.Id("customer.password")).SendKeys(details.Password);
            brwDriver.FindElement(By.Id("repeatedPassword")).SendKeys(details.Confirm);

            brwDriver.FindElement(By.XPath("//input[@value='Register']")).Click();

            return brwDriver.FindElement(By.XPath("//h1[@class='title']")).Text.Equals($"Welcome {details.Username}");
        }
    }

    public class CustomerDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string SSN { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Confirm { get; set; }
    }
}
