using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Pom_Struct.PWtests.Page
{
    internal class LoginPagenew
    {
        private IPage _page;
        private ILocator LinkLogin => _page.Locator(selector: "text=Login");
        private ILocator InpUserName=> _page.Locator(selector: "#UserName");
        private ILocator InpPassword=> _page.Locator(selector: "#Password");
        private ILocator BtnLogin => _page.Locator(selector: "input", new PageLocatorOptions
        {
            HasTextString = "Log in"
        });
        private ILocator LnkWelMessage=> _page.Locator(selector: "text='Hello admin!'");

        public LoginPagenew(IPage page)=>_page=page;
        public async Task ClickLoginLink()=>await LinkLogin.ClickAsync();
        public async Task Login(string userName, string password)

        {
            await InpUserName.FillAsync(userName);
            await InpPassword.FillAsync(password);
            await BtnLogin.ClickAsync();
        }
        public async Task<bool> ChkWelMsg()=> await LnkWelMessage.IsVisibleAsync();
    }
}
