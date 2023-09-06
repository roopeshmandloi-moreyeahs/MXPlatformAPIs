using Microsoft.AspNetCore.Mvc;
using MXPlatformAPI.Repositories;
using MXPlatformAPI.Responses;
using MXPlatformAPI.Validator;
using MXPlatformAPI.Validator.Interfaces;
using static MXPlatformAPI.Requests.RequestModels;

namespace MXPlatformAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
     
        private readonly IUserValidation _validation;
        readonly IConfiguration _config;

        public UserController(ILogger<UserController> logger, IUserValidation validation, IConfiguration config)
        {
            _logger = logger;
            _validation = validation;
            _config = config;
        }

        /// <summary>
        /// Create User 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>user_guid</returns>

        [HttpPost(nameof(CreateUser))]

        public async Task<ResponseMessage> CreateUser([FromBody] Root user)
        {
            ResponseMessage _response = new();
            Data data = new();
            UserRepository _userRepository = new(_config);
            ErrorResponse? errorResponse;
            try
            {
                #region Validate Request Model
                var validation = await _validation.CreateUserValidator.ValidateAsync(user);
                errorResponse = CustomResponseValidator.CheckModelValidation(validation);

                if (errorResponse != null)
                {
                    _response.Status = false;
                    _response.Message = "Validation Error(s)!";
                    data.JsonData = errorResponse.Data;
                    _response.Data = data;
                    return _response;
                }
                #endregion
                var result = await _userRepository.CreateUser(user);
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "User created.";
                    _logger.LogInformation("User created successfully.");
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "User not created.";
                    _logger.LogCritical("User not created!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoggingAt:{date} RequestIdentifier:{api} Exception:{ex}", DateTime.Now, "create", ex);
                _response.Status = false;
                _response.Message = ex.Message;
                return _response;
            }
            return _response;
        }

        /// <summary>
        /// List users
        /// </summary>
        /// <param></param>
        /// <returns>list of users</returns>
        [HttpGet(nameof(ListUser))]
        public async Task<ResponseMessage> ListUser()
        {
            ResponseMessage _response = new();
            UserRepository _userRepository = new(_config);
            try
            {
                var result = await _userRepository.ListUser();
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "User list found.";
                    _logger.LogInformation("User list found successfully.");
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "User list not found!";
                    _logger.LogCritical("User list not found!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoggingAt:{date} RequestIdentifier:{api} Exception:{ex}", DateTime.Now, "user list", ex);
                _response.Status = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
