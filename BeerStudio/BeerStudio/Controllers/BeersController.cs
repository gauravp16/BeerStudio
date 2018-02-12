using System;
using BeerStudio.Data;
using Microsoft.AspNetCore.Mvc;

namespace BeerStudio.Controllers
{
    [Route("api/[controller]")]
    public class BeersController : Controller
    {
        private IRepository _repo = null;

        public BeersController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var beers = _repo.GetAllBeers();

                if (beers == null || beers.Count == 0)
                    return StatusCode(500);

                return Ok(beers);
            }
            catch(Exception ex)
            {
                //log the actual error
                Console.WriteLine("Error while fetching all beers", ex);
                return StatusCode(500);
            }

        }
    }
}
