using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ParaBankSeleniumTests
{
    public class Tests
    {
        ChromeDriver chromeDriver;

        [SetUp]
        public void Setup()
        {
            chromeDriver = new Driver().TestChromeDriver;           
        }

        [Test]
        public void RegisterCustomerTest()
        {
            var customerDetails = new CustomerDetails();
            customerDetails.FirstName = "TestFN";
            customerDetails.LastName = "TestLN";
            customerDetails.Address = " Test AddressTest AddressTest Address ";
            customerDetails.City = "TestCity";
            customerDetails.State = "TestState";
            customerDetails.ZipCode = "TestZipCode";
            customerDetails.Phone = "1234567891";
            customerDetails.SSN = "123456";
            customerDetails.Username = "TestUsername4";
            customerDetails.Password = "TestPassword";
            customerDetails.Confirm = "TestPassword";

            CustomerPage cp = new CustomerPage(chromeDriver);
            var registered = cp.Register(customerDetails);
            registered.Should().BeTrue();
        }

        [Test]
        public void OpenNewAccountTest()
        {
            ParaBankLogin("TestUsername4", "TestPassword");
            chromeDriver.FindElement(By.XPath("//a [@href='openaccount.htm']")).Click();
            chromeDriver.FindElement(By.XPath("//select[@id='type'] / option[text()='SAVINGS'] ")).Click();
            chromeDriver.FindElement(By.XPath("//select[@id='fromAccountId'] / option[text()='15342'] ")).Click();
            chromeDriver.FindElement(By.XPath("//input[@value='Open New Account']")).Click();

            var accountOpened= chromeDriver.FindElement(By.Id("openAccountResult")).Text.Contains("Account Opened!");
            accountOpened.Should().BeTrue();
        }

        [Test]
        public void LoginTest()
        {
            IWebElement login = ParaBankLogin("john", "password");
            login.Should().NotBeNull();
        }

        private IWebElement ParaBankLogin(string name, string pwd)
        {
            var loginPage = new LoginPage(chromeDriver, name, pwd);
            var login = loginPage.login();
            return login;
        }

        [TearDown]
        public void TearDown()
        {
            chromeDriver.Quit();
        }
    }
}
