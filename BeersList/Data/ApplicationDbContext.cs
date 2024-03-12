using BeersList.Models;
using Microsoft.EntityFrameworkCore;

namespace BeersList.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Beers> Beers { get; set; }
        public DbSet<Breweries> Breweries { get; set; }

    }
}
