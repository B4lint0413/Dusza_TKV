using DuszaTKVGameLib.DTOs.GameDTOs;
using FluentValidation;

namespace BettingGameAPI.Validators
{
    public class GameValidator : AbstractValidator<CreateGameDto>
    {
        public GameValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Name length limit reached.");
        }
    }
}
