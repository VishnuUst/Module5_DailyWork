using Microsoft.Playwright;
using System.Text.Json;

namespace PlaywrightWith_Api
{
    public class ReqResApiTest
    {
        IAPIRequestContext reqRescontext;
        [SetUp]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            reqRescontext = await playwright.APIRequest.NewContextAsync(
                new APIRequestNewContextOptions
                {
                    BaseURL = "https://reqres.in/api/"
                });

        }

        [Test]
        public async Task GetAllUser()
       
        {
            var getresponse = await reqRescontext.GetAsync(url: "users?page=2");

            await Console.Out.WriteLineAsync("Res: \n"  + getresponse.ToString());
            await Console.Out.WriteLineAsync("Code:\n" + getresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + getresponse.StatusText);

            Assert.That(getresponse.Status.Equals(200));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responseBody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Res Body :\n" + responseBody.ToString());

            

        }
        [Test]
        public async Task GetSinglelUser()

        {
            var getresponse = await reqRescontext.GetAsync(url: "users/2");

            await Console.Out.WriteLineAsync("Res: \n" + getresponse.ToString());
            await Console.Out.WriteLineAsync("Code:\n" + getresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + getresponse.StatusText);

            Assert.That(getresponse.Status.Equals(200));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responseBody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Res Body :\n" + responseBody.ToString());



        }
        [Test]
        public async Task GetSinglelUserNotFound()

        {
            var getresponse = await reqRescontext.GetAsync(url: "users/23");

            await Console.Out.WriteLineAsync("Res: \n" + getresponse.ToString());
            await Console.Out.WriteLineAsync("Code:\n" + getresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + getresponse.StatusText);

            Assert.That(getresponse.Status.Equals(404));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responseBody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Res Body :\n" + responseBody.ToString());
            Assert.That(responseBody.ToString, Is.EqualTo("{}"));



        }
        [Test]
        public async Task PostUser()

        {
            var postData = new
            {
                name = "John",
                job = "Lead"
            };
            var jsonData = System.Text.Json.JsonSerializer.Serialize(postData);

            var postresponse = await reqRescontext.PostAsync(url: "users",
                new APIRequestContextOptions
                {
                    Data = jsonData
                });

            await Console.Out.WriteLineAsync("Res: \n" +postresponse.ToString());
            await Console.Out.WriteLineAsync("Code:\n" + postresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + postresponse.StatusText);

            Assert.That(postresponse.Status.Equals(201));
            Assert.That(postresponse, Is.Not.Null);

        }
        [Test]
        public async Task PutUser()

        {
            var postData = new
            {
                name = "John",
                job = "Lead"
            };
            var jsonData = System.Text.Json.JsonSerializer.Serialize(postData);

            var postresponse = await reqRescontext.PutAsync(url: "users/2",
                new APIRequestContextOptions
                {
                    Data = jsonData
                });

            await Console.Out.WriteLineAsync("Res: \n" + postresponse.ToString());
            await Console.Out.WriteLineAsync("Code:\n" + postresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + postresponse.StatusText);

            Assert.That(postresponse.Status.Equals(200));
            Assert.That(postresponse, Is.Not.Null);

        }
        [Test]
        [TestCase(2)]
        public async Task DeleteUser(int id)

        {

            var postresponse = await reqRescontext.DeleteAsync(url: "users/" + id);
                
            await Console.Out.WriteLineAsync("Res: \n" + postresponse.ToString());
            await Console.Out.WriteLineAsync("Code:\n" + postresponse.Status);
            await Console.Out.WriteLineAsync("Text:\n" + postresponse.StatusText);

            Assert.That(postresponse.Status.Equals(204));
            Assert.That(postresponse, Is.Not.Null);

        }
    }
}