using AutoMapper;
using BeersList.Data.DTOs.BreweriesDTO;
using BeersList.Models;

namespace BeersList.Data.MappingProfiles
{
    public class BreweriesMappingProfile : Profile
    {
        public BreweriesMappingProfile()
        {
            CreateMap<Breweries, BreweriesGetDTO>();
            CreateMap<BreweriesPostDTO, Breweries>();
            CreateMap<BreweriesPutDTO, Breweries>();
        }
    }
}
