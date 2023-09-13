using Microsoft.AspNetCore.Mvc;
using MXPlatformAPI.Repositories;
using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Controllers
{
    public class InstitutionController : Controller
    {
        private readonly ILogger<InstitutionController> _logger;
        readonly IConfiguration _config;
        public InstitutionController(ILogger<InstitutionController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }
        [HttpGet(nameof(ListInstitutions))]
        public async Task<ResponseMessage> ListInstitutions()
        {
            ResponseMessage _response = new();
            InstitutionRepository _institutionRepository = new(_config);
            try
            {
                var result = await _institutionRepository.ListInstitutions();
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
        public async Task<ResponseMessage> GetInstitutionCredential(string instituteCode)
        {
            ResponseMessage _response = new();
            InstitutionRepository _institutionRepository = new(_config);
            try
            {
                //Validate institution code 
                if (string.IsNullOrEmpty(instituteCode)) //Not entered or blank
                {
                    _response.Status = false;
                    _response.Message = "Invalid Institution code.";
                    return _response;
                }
                var result = await _institutionRepository.GetInstituteCredential(instituteCode);
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
