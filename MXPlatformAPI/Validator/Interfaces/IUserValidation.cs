﻿
using MXPlatformAPI.Validator.Interfaces;

namespace MXPlatformAPI.Validator.Interfaces
{
    public interface IUserValidation
    {
        public UserValidator CreateUserValidator { get; set; }
    }
}