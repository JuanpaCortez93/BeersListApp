using BeersList.Data.DTOs.BreweriesDTO;
using FluentValidation;

namespace BeersList.Data.Format_Validations.BreweriesFormatValidations
{
    public class BreweriesPostFormatValidation : AbstractValidator<BreweriesPostDTO>
    {
        public BreweriesPostFormatValidation() 
        {
            RuleFor(brewery => brewery.Name).NotNull().NotEmpty();
            RuleFor(brewery => brewery.Country).NotNull().NotEmpty();

            RuleFor(brewery => brewery.Name).Length(0,100);
            RuleFor(brewery => brewery.Country).Length(0, 50);
        }
    }
}
