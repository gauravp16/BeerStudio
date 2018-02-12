using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerStudio.DTOs
{
    public class BeerDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Abv { get; set; }
        public string IsOrganic { get; set; }
        public string Description { get; set; }
    }
}
