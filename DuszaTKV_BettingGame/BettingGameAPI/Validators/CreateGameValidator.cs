using DuszaTKVGameLib.DTOs.GameDTOs;
using FluentValidation;

namespace BettingGameAPI.Validators
{
    public class CreateGameValidator : AbstractValidator<CreateGameDto>
    {
        public CreateGameValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Name length limit reached.");
        }
    }
}
