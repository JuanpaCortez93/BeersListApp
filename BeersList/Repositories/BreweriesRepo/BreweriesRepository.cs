using BeersList.Data;
using BeersList.Models;
using Microsoft.EntityFrameworkCore;

namespace BeersList.Repositories.BreweriesRepo
{
    public class BreweriesRepository : IBreweriesRepository
    {

        private readonly ApplicationDbContext _appDbcontext;

        public BreweriesRepository(ApplicationDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }

        public async Task<IEnumerable<Breweries>> GetBreweries() => await _appDbcontext.Breweries.ToListAsync();

        public async Task<Breweries> GetBrewery(Guid? id) => await _appDbcontext.Breweries.FindAsync(id);

        public async Task AddBreweries(Breweries breweries) => await _appDbcontext.Breweries.AddAsync(breweries);

        public void UpdateBraweries(Breweries breweries)
        {
            _appDbcontext.Breweries.Attach(breweries);
            _appDbcontext.Breweries.Entry(breweries).State = EntityState.Modified;
        }

        public void DeleteBraweries(Breweries breweries) => _appDbcontext.Breweries.Remove(breweries);

        public async Task SaveChanges() => await _appDbcontext.SaveChangesAsync();

    }
}
