using Microsoft.AspNetCore.Mvc;
using MXPlatformAPI.Repositories;
using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Controllers
{
    public class InstitutionController : Controller
    {
        private readonly ILogger<InstitutionController> _logger;
        readonly string? baseUrl;
        /// <summary>
        /// Basic Auth for Anutenticating the MAX Platform API's
        /// </summary>
        readonly string? basicAuth;

        public InstitutionController(ILogger<InstitutionController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            baseUrl = iConfig.GetSection("ApiSettings").GetSection("baseUrl").Value; ///Get base url from appsetting.json 
            basicAuth = iConfig.GetSection("ApiSettings").GetSection("basicAuth").Value; ///Get Basic Auth from appsetting.json 
        }

        [HttpGet(nameof(ListInstitutions))]
        public async Task<ResponseMessage> ListInstitutions()
        {
            ResponseMessage _response = new();
            InstitutionRepository institutionRepository = new();
            try
            {
                var result = await institutionRepository.ListInstitutions(baseUrl, basicAuth);
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "Institution list found.";
                    _logger.LogInformation("Institution list found successfully.");
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "Institution list not found!";
                    _logger.LogCritical("Institution list not found!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoggingAt:{date} RequestIdentifier:{api} Exception:{ex}", DateTime.Now, "institution list", ex);
                _response.Status = false;
                _response.Message = ex.Message;
                return _response;
            }
            return _response;
        }

        [HttpGet(nameof(GetInstitutionCredential))]
        public async Task<ResponseMessage> GetInstitutionCredential(string InstituteCode)
        {
            ResponseMessage _response = new();
            InstitutionRepository institutionRepository = new();
            try
            {
                //Validate institution code 
                if(string.IsNullOrEmpty(InstituteCode)) //Not entered or blank
                {
                    _response.Status = false;
                    _response.Message = "Invalid Institution code.";
                    return _response;
                }
                var result = await institutionRepository.GetInstituteCredential(InstituteCode, baseUrl, basicAuth);
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "Institution credential found.";
                    _logger.LogInformation("Institution credential found.");
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "Institution credential not found!";
                    _logger.LogCritical("Institution credential not found.!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoggingAt:{date} RequestIdentifier:{api} Exception:{ex}", DateTime.Now, "institution credential", ex);
                _response.Status = false;
                _response.Message = ex.Message;
                return _response;
            }
            return _response;
        }
    }
}
