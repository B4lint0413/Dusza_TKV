using DuszaTKVGameLib.DTOs.BetDTOs;
using FluentValidation;

namespace BettingGameAPI.Validators
{
    public class UpdateBetValidator : AbstractValidator<UpdateBetDto>
    {
        public UpdateBetValidator()
        {
            RuleFor(x => x.Result).NotEmpty().WithMessage("Result is required.");
            RuleFor(x => x.Result).MaximumLength(30).WithMessage("Result length limit reached.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required.");
            RuleFor(x => x.Subject).MaximumLength(30).WithMessage("Subject length limit reached.");
            RuleFor(x => x.Stake).NotEmpty().WithMessage("Stake is required.");
            RuleFor(x => x.Stake).GreaterThan(0).WithMessage("Stake must be greater than 0.");
        }
    }
}
