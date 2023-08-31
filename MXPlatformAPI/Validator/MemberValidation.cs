using FluentValidation;
using static MXPlatformAPI.Requests.RequestModels;

namespace MXPlatformAPI.Validator
{
public class MemberValidator : AbstractValidator<CreateMemberRoot>
    {
        public MemberValidator()
        {
            RuleFor(user => user.Member.InstitutionCode).NotEmpty().WithMessage("Institution code is required.");
            RuleFor(user => user.Member.Id).NotEmpty().WithMessage("Id is required!");
            RuleFor(user => user.Member.Credentials).NotEmpty().WithMessage("Institution Credential is required!");
            RuleFor(user => user.Member.IsOauth).NotNull().WithMessage("Is Outh is required!");
            RuleFor(user => user.ReferralSource).NotEmpty().WithMessage("Referral Source is required!");
            
        }
    }

}

