

using MXPlatformAPI.Validator.Interfaces;

namespace MXPlatformAPI.Validator.Services
{
    public class MemberValidation : IMemberValidation
    {
        public MemberValidator CreateMemberValidator { get; set; } = new();
    }
}
