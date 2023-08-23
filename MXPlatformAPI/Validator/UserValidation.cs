using FluentValidation;
using static MXPlatformAPI.Requests.RequestModels;

namespace MXPlatformAPI.Validator
{
public class UserValidator : AbstractValidator<Root>
    {
        public UserValidator()
        {
            RuleFor(user => user.user.id).NotEmpty().WithMessage("id is required.");
            RuleFor(user => user.user.email).NotEmpty().WithMessage("Email address is required!")
                            .EmailAddress().WithMessage("A valid email is required.");
        }
    }

}

