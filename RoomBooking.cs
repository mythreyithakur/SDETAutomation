using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace PlaywrightTests
{
    public class RoomBooking 
    {
        IPage _page;
        public RoomBooking(IPage page)
        {
            this._page = page; 
        }
        public async Task loginAndBookRoom()
        {
            var roomNumber = new Random().Next(106, 200);

            await Login();
            await BookARoom(roomNumber);

            ClickFrontPage();

            await CreateContact();
            
        }

        async Task Login()
        {
            await _page.GetByText("Admin", new PageGetByTextOptions { Exact = true }).ClickAsync();
            await _page.Locator("#username").FillAsync("");
            await _page.Locator("#password").FillAsync("");
            await _page.Locator("#username").FillAsync("admin");
            await _page.Locator("#password").FillAsync("password");
            await _page.Locator("#doLogin").ClickAsync();
        }

        async Task BookARoom(int roomNumber)
        {
            await _page.Locator("#roomName").FillAsync(roomNumber.ToString());
            await _page.SelectOptionAsync("select#type", new[] { "Suite" });
            await _page.SelectOptionAsync("select#accessible", new[] { "true" });
            await _page.Locator("#roomPrice").FillAsync("500");
            await _page.CheckAsync("input#wifiCheckbox");
            await _page.CheckAsync("input#wifiCheckbox");
            await _page.CheckAsync("input#safeCheckbox");
            await _page.Locator("#createRoom").ClickAsync();
        }

        void ClickFrontPage()
        {
            var requestFrontPage = _page.RunAndWaitForRequestAsync(async () =>
            {
                await _page.Locator("#frontPageLink").ClickAsync();

            }, "https://automationintesting.online/");

           // var decodedUrl= HttpUtility.UrlDecode(requestFrontPage.Result.Url);
        }

        async Task CreateContact()
        {
            var requestContact = _page.RunAndWaitForRequestAsync(async () =>
            {
                await _page.Locator("#navbarNav").GetByText("Contact", new LocatorGetByTextOptions() { Exact = true }).ClickAsync();
            }, "https://automationintesting.online/#contact");

            await _page.Locator("#name").FillAsync("testing1");
            await _page.Locator("#email").FillAsync("testing1@testing.com");
            await _page.Locator("#phone").FillAsync("12345678912");
            await _page.Locator("#subject").FillAsync("autotesting1");
            await _page.Locator("#description").FillAsync("testmessage testmessage testmessage testmessage");
            await _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { Name = "Submit" }).ClickAsync();

            await _page.Locator(".card shadow").IsVisibleAsync();
        }

        public async Task<bool> IsLoginSuccess(IPage page) 
        {
           return page.Url.Contains("**/admin/rooms");
        }

        public async Task BBCNews()
        {             
           await this._page.Locator("#global-navigation").GetByText("News",new LocatorGetByTextOptions() { Exact=true}).ClickAsync();

        }
    }

}
