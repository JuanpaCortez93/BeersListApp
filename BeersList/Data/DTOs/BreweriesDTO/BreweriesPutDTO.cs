namespace BeersList.Data.DTOs.BreweriesDTO
{
    public class BreweriesPutDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
    }
}
