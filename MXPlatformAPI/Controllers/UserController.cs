using Microsoft.AspNetCore.Mvc;
using MXPlatformAPI.Repositories;
using MXPlatformAPI.Responses;
using static MXPlatformAPI.Requests.RequestModels;

namespace MXPlatformAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        readonly string BaseUrl;
        public UserController(IConfiguration iConfig, ILogger<UserController> logger)
        {
            BaseUrl = iConfig.GetSection("ApiSettings").GetSection("BaseUrl").Value;
            _logger = logger;
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
            UserRepository userRepository = new();
            try
            {
                var result = await userRepository.CreateUser(user, BaseUrl);
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "User created.";
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "User not created.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(!string.IsNullOrEmpty(ex.Message)?ex.Message:"Error", ex);
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
            UserRepository userRepository = new();
            try
            {
                var result = await userRepository.ListUser(BaseUrl);
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "User list found.";
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "User list not found!";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(!string.IsNullOrEmpty(ex.Message) ? ex.Message : "Error", ex);
                _response.Status = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
