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
        [Test]
        public async Task LoginTest()
        {
            Console.WriteLine("Opened browser");

            await Page.GotoAsync("http://eaapp.somee.com/");

            Console.WriteLine("Page loaded");
            await Page.GetByText("Login").ClickAsync();
            await Console.Out.WriteLineAsync("Login Link Clicked");
            await Expect(Page).ToHaveURLAsync("http://eaapp.somee.com/Account/Login");
            await Page.GetByLabel("UserName").FillAsync(value: "admin");
            await Page.GetByLabel("Password").FillAsync(value: "password");
            await Console.Out.WriteLineAsync("Username and password is typed");
            await Page.Locator("//input[@value='Log in']").ClickAsync();
            await Expect(Page).ToHaveTitleAsync("Home - Execute Automation Employee App");
            await Console.Out.WriteLineAsync("Login succefully!!");
        }
    }
}
