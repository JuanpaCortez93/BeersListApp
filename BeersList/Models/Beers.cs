using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeersList.Models
{
    public class Beers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal ABV { get; set;}
        [Column(TypeName = "decimal(5,2)")]
        public decimal IBU { get; set;}
        public Guid BreweryId { get; set; }

        [ForeignKey("BreweryId")]
        public virtual Breweries? Breweries { get; set; }

    }
}
