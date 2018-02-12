using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Tests
{
    [TestClass]
    public class ApiTests
    {
        private const string URL = "http://localhost:1974/api";

        [TestMethod]
        public void Should_Return_Beers_And_Status_Code_As_200()
        {
            var response = CallApi("beers").Result;

            response.EnsureSuccessStatusCode();

            var data = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(JArray.Parse(data).Count, 2);
        }

        [TestMethod]
        public void Should_Return_Status_Code_As_404_In_Case_Of_Incorrect_Path()
        {
            var response = CallApi("beerss").Result;

            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void Should_Return_Beer_Details()
        {
            var response = CallApi("beers/123").Result;

            response.EnsureSuccessStatusCode();

            var data = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(data["id"].ToString(), "123");
            Assert.AreEqual(data["description"].ToString(), "Hop Heads this one's for you! Checking in with 143 IBU's this ale punches you in the mouth with extreme bitterness then rounds out with toffee flavors and finishes with a citrus aroma. Made with tons of US 2 Row Barley to get this to ABV 11.1%.");
        }

        [TestMethod]
        public void Should_Return_Bad_Reuqest_In_Case_Of_Bad_Id()
        {
            var response = CallApi("beers/678").Result;

            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        private Task<HttpResponseMessage> CallApi(string path)
        {
            HttpClient client = new HttpClient();
            return client.GetAsync(string.Format("{0}/{1}", URL, path));
        }
    }
}
