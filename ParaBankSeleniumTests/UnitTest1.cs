using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace ParaBankSeleniumTests
{
    public class Tests
    {
        EdgeDriver browserDriver;

        [SetUp]
        public void Setup()
        {
            browserDriver = new Driver().TestBrowserDriver;           
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
            customerDetails.Username = "TestUsername";
            customerDetails.Password = "TestPassword";
            customerDetails.Confirm = "TestPassword";

            CustomerPage cp = new CustomerPage(browserDriver);
            var registered = cp.Register(customerDetails);
            registered.Should().BeTrue();
        }

        [Test]
        public void OpenNewAccountTest()
        {
            ParaBankLogin("TestUsername", "TestPassword");
            browserDriver.FindElement(By.XPath("//a [@href='openaccount.htm']")).Click();
            browserDriver.FindElement(By.XPath("//select[@id='type'] / option[text()='SAVINGS'] ")).Click();

            var fromAccount = browserDriver.FindElement(By.XPath("//select[@id='fromAccountId'] "));
            var fromAccountSelect = new SelectElement(fromAccount);

            Thread.Sleep(1000);
            fromAccountSelect.SelectedOption.Click();

            browserDriver.FindElement(By.XPath("//input[@value='Open New Account']")).Click();

            Thread.Sleep(2000);

            var accountOpened= browserDriver.FindElement(By.Id("openAccountResult")).Text.Contains("Account Opened!");
            accountOpened.Should().BeTrue();
        }

        [Test]
        public void LoginTest()
        {
            IWebElement login = ParaBankLogin("TestUsername", "TestPassword");
            login.Should().NotBeNull();
        }

        private IWebElement ParaBankLogin(string name, string pwd)
        {
            var loginPage = new LoginPage(browserDriver, name, pwd);
            var login = loginPage.login();
            return login;
        }

        [TearDown]
        public void TearDown()
        {
            browserDriver.Quit();
        }
    }
}
