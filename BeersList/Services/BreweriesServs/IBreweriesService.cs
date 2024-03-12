using BeersList.Data.DTOs.BreweriesDTO;
using Microsoft.AspNetCore.Mvc;

namespace BeersList.Services.BreweriesServs
{
    public interface IBreweriesService <TGet, TPost, TPut>
    {
        Task<IEnumerable<TGet>> Index();
        Task CreatePost(TPost tPost);
        Task<TGet> EditGet(Guid? id);
        Task<TGet> EditPost(TPut tPut);
        Task<TGet> DeleteGet(Guid? id);
        Task<TGet> DeletePost(TGet tGet);

    }
}
