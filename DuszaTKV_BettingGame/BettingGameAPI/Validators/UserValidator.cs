using BettingGameAPI.Models;
using DuszaTKVGameLib.DTOs.UserDTOs;
using FluentValidation;

namespace BettingGameAPI.Validators
{
    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        public UserValidator(IDataStore data)
        {
            RuleFor(x => x.Name).Must(name => data.Users.Values.All(user => user.Name != name)).WithMessage("Name already exists.");
        }
    }
}
