using BeersList.Models;

namespace BeersList.Repositories.BreweriesRepo
{
    public interface IBreweriesRepository
    {
        Task<IEnumerable<Breweries>> GetBreweries();
        Task<Breweries> GetBrewery(Guid? id);
        Task AddBreweries(Breweries breweries);
        void UpdateBraweries(Breweries breweries);
        void DeleteBraweries(Breweries breweries); 
        Task SaveChanges();
    }
}
