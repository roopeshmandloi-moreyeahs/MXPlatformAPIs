using Microsoft.AspNetCore.Mvc;
using MXPlatformAPI.Repositories;
using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _config;

        public AccountController(ILogger<AccountController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config= configuration;
        }

        [HttpGet(nameof(ListAccountData))]
        public async Task<ResponseMessage> ListAccountData(string userGuid)
        {
            ResponseMessage _response = new();
            AccountRepository _accountRepository = new(_config);
            try
            {
                //userGuid validation
                if (string.IsNullOrEmpty(userGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid User Guid!";
                    return _response;
                }

                    #pragma warning disable CS8604 // Possible null reference argument.
                var result = await _accountRepository.ListAccountData(userGuid);

                    #pragma warning restore CS8604 // Possible null reference argument.
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "Account Data list found.";
                    _logger.LogInformation("Account Data found successfully.");
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "Account Data list not found!";
                    _logger.LogCritical("Account Data list not found!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoggingAt:{date} RequestIdentifier:{api} Exception:{ex}", DateTime.Now, "account data", ex);
                _response.Status = false;
                _response.Message = ex.Message;
                return _response;
            }
            return _response;
        }

    }
}
