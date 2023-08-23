using FluentValidation;
using static MXPlatformAPI.Requests.RequestModels;

namespace MXPlatformAPI.Validator
{
public class MemberValidator : AbstractValidator<CreateMemberRoot>
    {
        public MemberValidator()
        {
            RuleFor(user => user.member.institution_code).NotEmpty().WithMessage("institution code is required.");
            RuleFor(user => user.member.id).NotEmpty().WithMessage("id is required!");
            RuleFor(user => user.member.credentials).NotEmpty().WithMessage("institution credential is required!");
            RuleFor(user => user.member.is_oauth).NotNull().WithMessage("institution credential is required!");
            RuleFor(user => user.referral_source).NotEmpty().WithMessage("referral source is required!");
            
        }
    }

}

