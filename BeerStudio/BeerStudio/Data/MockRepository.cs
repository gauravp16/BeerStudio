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
            _beers.Add("123", new Beer() { Id = "123", Abv = "11.1", Name = "Organic" });
            _beers.Add("456", new Beer() { Id = "456", Abv = "15.1", Name = "Not Organic" });
        }
        public ICollection<Beer> GetAllBeers()
        {
            return _beers.Values;
        }
    }
}
