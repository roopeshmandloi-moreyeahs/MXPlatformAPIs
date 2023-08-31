using FluentValidation;
using static MXPlatformAPI.Requests.RequestModels;

namespace MXPlatformAPI.Validator
{
    public class UserValidator : AbstractValidator<Root>
    {
        public UserValidator()
        {
            RuleFor(user => user.User.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(user => user.User.Email).NotEmpty().WithMessage("Email address is required!")
                            .EmailAddress().WithMessage("A valid email is required.");
        }
    }

}

