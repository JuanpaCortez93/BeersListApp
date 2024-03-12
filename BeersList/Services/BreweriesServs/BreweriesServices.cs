using AutoMapper;
using BeersList.Data;
using BeersList.Data.DTOs.BreweriesDTO;
using BeersList.Models;
using BeersList.Repositories.BreweriesRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeersList.Services.BreweriesServs
{
    public class BreweriesServices : IBreweriesService<BreweriesGetDTO, BreweriesPostDTO, BreweriesPutDTO>
    {

        private ApplicationDbContext _appDbcontext;
        private IMapper _breweryMapper;
        private IBreweriesRepository _breweriesRepository;

        public BreweriesServices(ApplicationDbContext applicationDbContext, IMapper breweryMapper, [FromKeyedServices("BreweriesRepository")]IBreweriesRepository breweriesRepository)
        {
            _appDbcontext = applicationDbContext;
            _breweryMapper = breweryMapper;
            _breweriesRepository = breweriesRepository;
        }

        public async Task<IEnumerable<BreweriesGetDTO>> Index()
        {
            var breweries = await _breweriesRepository.GetBreweries();
            var breweriesDTO = breweries.Select(brewery => _breweryMapper.Map<BreweriesGetDTO>(brewery));

            return breweriesDTO;
        }

        public async Task CreatePost(BreweriesPostDTO tPost)
        {
            var breweries = _breweryMapper.Map<Breweries>(tPost);
            await _breweriesRepository.AddBreweries(breweries);
            await _breweriesRepository.SaveChanges();

        }

        public async Task<BreweriesGetDTO> EditGet(Guid? id)
        {
            var breweries = await _breweriesRepository.GetBrewery(id);
            if (breweries == null) return null;
            var breweriesDTO = _breweryMapper.Map<BreweriesGetDTO>(breweries);

            return breweriesDTO;
        }

        public async Task<BreweriesGetDTO> EditPost(BreweriesPutDTO tPut)
        {
            var breweries = await _appDbcontext.Breweries.FindAsync(tPut.Id);
            if (breweries == null) return null;

            breweries = _breweryMapper.Map<BreweriesPutDTO, Breweries>(tPut, breweries);

            _breweriesRepository.UpdateBraweries(breweries);
            await _breweriesRepository.SaveChanges();

            var breweriesDTO = _breweryMapper.Map<BreweriesGetDTO>(breweries);

            return breweriesDTO;
        }

        public async Task<BreweriesGetDTO> DeleteGet(Guid? id)
        {
            var breweries = await _breweriesRepository.GetBrewery(id);
            if (breweries == null) return null;
            var breweriesDTO = _breweryMapper.Map<BreweriesGetDTO>(breweries);

            return breweriesDTO;
        }

        public async Task<BreweriesGetDTO> DeletePost(BreweriesGetDTO tGet)
        {
            var breweries = await _breweriesRepository.GetBrewery(tGet.Id);
            if (breweries == null) return null;

            _breweriesRepository.DeleteBraweries(breweries);
            await _breweriesRepository.SaveChanges();

            var breweriesDTO = _breweryMapper.Map<BreweriesGetDTO>(breweries);
            return breweriesDTO;
        }


    }
}
