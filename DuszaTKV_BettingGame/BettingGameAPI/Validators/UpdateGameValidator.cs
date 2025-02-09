using DuszaTKVGameLib.DTOs.GameDTOs;
using FluentValidation;

namespace BettingGameAPI.Validators
{
    public class UpdateGameValidator : AbstractValidator<UpdateGameDto>
    {
        public UpdateGameValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Name length limit reached.");
        }
    }
}
