using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightNunit
{
  
    internal class GHPTests :PageTest
    {
        //[Test]
        //public async Task Test1()
        //{
        //    //playwright startup
        //    using var playwright = await Playwright.CreateAsync();

        //    //launch browser
        //    await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        //    {
        //        Headless = false
        //    });

        //    //page instance
        //    var context = await browser.NewContextAsync();
        //    var page = await context.NewPageAsync();

        //    Console.WriteLine("Opened browser");

        //    await page.GotoAsync("https://www.google.com");

        //    Console.WriteLine("Page loaded");

        //    //locator and send data
        //    ////await page.GetByTitle("Search").FillAsync("Hp laptop");
        //    await page.Locator("#APjFqb").FillAsync("selenium");
        //    Console.WriteLine("Typed");
        //    //await page.GetByText("Google Search").ClickAsync();
        //    //Console.WriteLine("Clicked");
        //    await page.Locator("(//input[@value='Google Search'])[2]").ClickAsync();
        //    Console.WriteLine("Clicked");


        //}


        [Test]
        public async Task Test2()
        {


            Console.WriteLine("Opened browser");

            await Page.GotoAsync("https://www.google.com");

            Console.WriteLine("Page loaded");

            string title = await Page.TitleAsync();
            Console.WriteLine(title);
            //locator and send data
            ////await page.GetByTitle("Search").FillAsync("Hp laptop");

            await Page.Locator("#APjFqb").FillAsync("selenium");
            Console.WriteLine("Typed");
            //await page.GetByText("Google Search").ClickAsync();
            //Console.WriteLine("Clicked");
            await Page.Locator("(//input[@value='Google Search'])[2]").ClickAsync();
            Console.WriteLine("Clicked");

            //title = await Page.TitleAsync();
            //Console.WriteLine(title);

            //Assert.That(title, Does.Contain("selenium"));
            await Expect(Page).ToHaveTitleAsync("selenium - Google Search");

        }
    }
}
