using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaap_test
{
    [TestFixture]
    internal class EaappTest : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            Console.WriteLine("Opened browser");

            await Page.GotoAsync("http://eaapp.somee.com/");

            Console.WriteLine("Page loaded");
        }
        [Test]
        public async Task LoginTest()
        {
            
            /* 3 way to find locators*/
            //await Page.GetByText("Login").ClickAsync();
            //var lnkLogin = Page.Locator(selector: "text =Login");
            //await lnkLogin.ClickAsync();
            await Page.ClickAsync(selector: "text=Login");


            await Console.Out.WriteLineAsync("Login Link Clicked");
            await Expect(Page).ToHaveURLAsync("http://eaapp.somee.com/Account/Login");
            await Page.GetByLabel("UserName").FillAsync(value: "admin");
            await Page.GetByLabel("Password").FillAsync(value: "password");
            await Console.Out.WriteLineAsync("Username and password is typed");
            //await Page.Locator("//input[@value='Log in']").ClickAsync();
            var btnLogin = Page.Locator(selector: "input", new Microsoft.Playwright.PageLocatorOptions
            {
                HasTextString = "Log in"

            });
            await btnLogin.ClickAsync();

            await Expect(Page).ToHaveTitleAsync("Home - Execute Automation Employee App");
            await Console.Out.WriteLineAsync("Login succefully!!");
            await Page.GetByText("Employee Details").ClickAsync();
            await Expect(Page).ToHaveURLAsync("http://eaapp.somee.com/EmployeeDetails");
            await Console.Out.WriteLineAsync("Employee details displayed successfully!!!");
        }
    }
}
