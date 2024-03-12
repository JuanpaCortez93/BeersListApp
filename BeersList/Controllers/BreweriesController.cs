using AutoMapper;
using BeersList.Data;
using BeersList.Data.DTOs.BreweriesDTO;
using BeersList.Models;
using BeersList.Services.BreweriesServs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeersList.Controllers
{
    public class BreweriesController : Controller
    {

        private IBreweriesService<BreweriesGetDTO, BreweriesPostDTO, BreweriesPutDTO> _breweriesService;

        public BreweriesController
            (
                [FromKeyedServices("BreweriesService")]IBreweriesService<BreweriesGetDTO, BreweriesPostDTO, BreweriesPutDTO> breweriesService
            )
        {
            _breweriesService = breweriesService;
        }

        public async Task<ActionResult<IEnumerable<BreweriesGetDTO>>> Index()
        {
            var breweriesDTO = await _breweriesService.Index();
            TempData["success"] = "Brewery list loaded";
            return View(breweriesDTO);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BreweriesPostDTO breweriesPostDTO)
        {

            await _breweriesService.CreatePost(breweriesPostDTO);
            TempData["success"] = "Brewery created";
            return RedirectToAction("Index", "Breweries");

        }

        public async Task<ActionResult<BreweriesGetDTO>> Edit(Guid? id)
        {
            var breweriesDTO = await _breweriesService.EditGet(id);
            return breweriesDTO != null ? View(breweriesDTO) : NotFound();
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BreweriesPutDTO breweriesPutDTO)
        {
            var breweriesDTO = await _breweriesService.EditPost(breweriesPutDTO);
            TempData["success"] = "Brewery updated";
            return breweriesDTO != null ? RedirectToAction("Index") : NotFound();
        }


        public async Task<ActionResult<BreweriesGetDTO>> Delete(Guid? id)
        {
            var breweriesDTO = await _breweriesService.EditGet(id);
            return breweriesDTO != null ? View(breweriesDTO) : NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(BreweriesGetDTO breweriesGetDTO)
        {

            var breweriesDTO = await _breweriesService.DeletePost(breweriesGetDTO);
            TempData["success"] = "Brewery deleted";
            return breweriesDTO != null ? RedirectToAction("Index") : NotFound();
        }


    }
}
