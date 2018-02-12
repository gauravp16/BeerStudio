
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BeerStudio.DTOs;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace BeerStudio.Data
{
    public class WebRepository : IRepository
    {
        private ApiSettings _apiSettings = null;

        public WebRepository(IOptions<ApiSettings> options)
        {
            _apiSettings = options.Value;
        }

        public ICollection<Beer> GetAllBeers()
        {
            var response = CallApi("beers");

            if (response.IsSuccessful)
            {
                JObject contentString = JObject.Parse(response.Content);

                IList<JToken> results = contentString["data"].Children().ToList();

                var beers = new List<Beer>();
                foreach (JToken result in results)
                {
                    beers.Add(result.ToObject<Beer>());
                }
                return beers;
            }
            else
            {
                Console.WriteLine("Error, failed to get all beers from the web api");
                return null;
            }
        }

        public BeerDetail GetBeer(string id)
        {
            var response = CallApi(string.Format("beer/{0}", id));

            if (response.IsSuccessful)
            {
                JObject contentString = JObject.Parse(response.Content);
                return contentString["data"].ToObject<BeerDetail>();
            }
            else
            {
                Console.WriteLine(string.Format("Error, failed to get beer details for id {0} from the web api", id));
                return null;
            }
        }

        private IRestResponse CallApi(string path)
        {
            var client = new RestClient(_apiSettings.Endpoint);
            var request = new RestRequest(path, Method.GET);
            request.AddQueryParameter("key", _apiSettings.Key);
            return client.Execute(request);
        }
    }
}
