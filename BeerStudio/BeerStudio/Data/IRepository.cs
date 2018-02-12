using System.Collections.Generic;
using BeerStudio.DTOs;

namespace BeerStudio.Data
{
    public interface IRepository
    {
        ICollection<Beer> GetAllBeers();
    }
}