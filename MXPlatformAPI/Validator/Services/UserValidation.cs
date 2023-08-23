

using MXPlatformAPI.Validator.Interfaces;

namespace MXPlatformAPI.Validator.Services
{
    public class UserValidation : IUserValidation
    {
        public UserValidator CreateUserValidator { get; set; } = new();
    }
}
