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

        private Task<HttpResponseMessage> CallApi(string path)
        {
            HttpClient client = new HttpClient();
            return client.GetAsync(string.Format("{0}/{1}", URL, path));
        }
    }
}
