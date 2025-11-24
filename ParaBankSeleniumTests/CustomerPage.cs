using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBankSeleniumTests
{
    public class CustomerPage
    {
        public ChromeDriver ChrDriver { get; set; }
        public CustomerPage(ChromeDriver driver)
        {
            ChrDriver = driver;
                 
        }

        public bool Register(CustomerDetails details)
        {
            ChrDriver.FindElement(By.XPath("//a[@href= 'register.htm']")).Click();

            ChrDriver.FindElement(By.Id("customer.firstName")).SendKeys(details.FirstName);
            ChrDriver.FindElement(By.Id("customer.lastName")).SendKeys(details.LastName);
            ChrDriver.FindElement(By.Id("customer.address.street")).SendKeys(details.Address);
            ChrDriver.FindElement(By.Id("customer.address.city")).SendKeys(details.City);
            ChrDriver.FindElement(By.Id("customer.address.state")).SendKeys(details.State);
            ChrDriver.FindElement(By.Id("customer.address.zipCode")).SendKeys(details.ZipCode);
            ChrDriver.FindElement(By.Id("customer.phoneNumber")).SendKeys(details.Phone);
            ChrDriver.FindElement(By.Id("customer.ssn")).SendKeys(details.State);
            ChrDriver.FindElement(By.Id("customer.username")).SendKeys(details.Username);
            ChrDriver.FindElement(By.Id("customer.password")).SendKeys(details.Password);
            ChrDriver.FindElement(By.Id("repeatedPassword")).SendKeys(details.Confirm);

            ChrDriver.FindElement(By.XPath("//input[@value='Register']")).Click();

            return ChrDriver.FindElement(By.XPath("//h1[@class='title']")).Text.Equals($"Welcome {details.Username}");
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
