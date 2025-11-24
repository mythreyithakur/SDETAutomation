using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests
{
    public class Tests : PageTest
    {
        RoomBooking pb;

        [SetUp]
        public async Task Setup()
        {
            pb = new RoomBooking(this.Page);
            await Page.GotoAsync("https://automationintesting.online/");
            //await Page.GotoAsync("https://www.bbc.co.uk/");
        }

       // [Test]
        public async Task Test1()
        {
            await pb.loginAndBookRoom();
        }
    }
}
