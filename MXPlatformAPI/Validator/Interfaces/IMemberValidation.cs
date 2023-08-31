
using MXPlatformAPI.Validator.Interfaces;

namespace MXPlatformAPI.Validator.Interfaces
{
    public interface IMemberValidation
    {
        public MemberValidator CreateMemberValidator { get; set; }
    }
}
