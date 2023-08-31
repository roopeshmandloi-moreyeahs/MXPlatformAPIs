using Microsoft.AspNetCore.Mvc;
using MXPlatformAPI.Repositories;
using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        /// <summary>
        /// Base URL of MAX Platform API's
        /// </summary>
        readonly string? baseUrl;
        /// <summary>
        /// Basic Auth for Anutenticating the MAX Platform API's
        /// </summary>
        readonly string? basicAuth;
        public AccountController(ILogger<AccountController> logger, IConfiguration iConfig)
        {
            _logger = logger;
             baseUrl = iConfig.GetSection("ApiSettings").GetSection("baseUrl").Value; ///Get base url from appsetting.json 
             basicAuth = iConfig.GetSection("ApiSettings").GetSection("basicAuth").Value; ///Get Basic Auth from appsetting.json 
        }

        [HttpGet(nameof(ListAccountData))]
        public async Task<ResponseMessage> ListAccountData(string UserGuid)
        {
            ResponseMessage _response = new();
            AccountRepository AccountRepository = new();
            try
            {
                //UserGuid validation
                if (string.IsNullOrEmpty(UserGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid User Guid!";
                    return _response;
                }
                
                #pragma warning disable CS8604 // Possible null reference argument.
                var result = await AccountRepository.ListAccountData(UserGuid, baseUrl, basicAuth);
                
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
