using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeersList.Data.DTOs.BreweriesDTO
{
    public class BreweriesGetDTO
    {
        public Guid Id { get; set; } 
        public string? Name { get; set; }
        public string? Country { get; set; }
    }
}
