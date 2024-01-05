using Microsoft.Playwright.NUnit;
using Playwright_Pom_Struct.PWtests.Page;
using Playwright_Pom_Struct.Test_DataClasses;
using Playwright_Pom_Struct.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Pom_Struct.PWtests.Test
{
    [TestFixture]
    public class LoginPageTest : PageTest
    {
        Dictionary<string, string>? properties;
        string? currdir;
        private void ReadConfiguration()
        {

            properties = new Dictionary<string, string>();
            currdir = Directory.GetParent(@"../../../")?.FullName;
            string fileName = currdir + "/configsettings/config.properties";
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line) && line.Contains('='))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
        }
        [SetUp]
        public async Task SetUp()
        {
            ReadConfiguration();
            Console.WriteLine("Opened browser");
            await Page.GotoAsync(properties["baseUrl"]);
            Console.WriteLine("Page loaded");
        }
        [Test]

        public async Task LoginTest()
        {
            LoginPagenew loginPage = new LoginPagenew(Page);
            string? excelFilePath = currdir + "/TestData/EAData.xlsx";
            string? sheetName = "Login Data";

            List<EAText> excelDataList = LoginDataRead.ReadLoginDataText(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? userName = excelData.UserName;
                string? password = excelData.Password;

                await loginPage.ClickLoginLink();
                await loginPage.Login(userName, password);
                await Page.ScreenshotAsync(new()
                {
                    Path = currdir + "/Screenshots/scrn.png"
                });
                Assert.IsTrue(await loginPage.ChkWelMsg());

            }
        }
    }
}
