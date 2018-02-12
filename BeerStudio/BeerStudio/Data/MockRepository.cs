using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerStudio.DTOs;

namespace BeerStudio.Data
{
    public class MockRepository : IRepository
    {
        private Dictionary<string, Beer> _beers = new Dictionary<string, Beer>();
        
        public MockRepository()
        {
            _beers.Add("123", new Beer() { Id = "123", Abv = 11.1, Name = "Imperial IPA 2" });
            _beers.Add("456", new Beer() { Id = "456", Abv = 15.1, Name = "American Pale Ale" });
        }
        public ICollection<Beer> GetAllBeers()
        {
            return _beers.Values;
        }

        public BeerDetail GetBeer(string id)
        {
            if (!_beers.ContainsKey(id))
                return null;

            return new BeerDetail() { Id = id, Abv = _beers[id].Abv, Description = "Hop Heads this one's for you! Checking in with 143 IBU's this ale punches you in the mouth with extreme bitterness then rounds out with toffee flavors and finishes with a citrus aroma. Made with tons of US 2 Row Barley to get this to ABV 11.1%.", IsOrganic = "N" };
        }
    }
}
