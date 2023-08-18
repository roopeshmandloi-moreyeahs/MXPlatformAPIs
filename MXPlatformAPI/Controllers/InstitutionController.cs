using Microsoft.AspNetCore.Mvc;
using MXPlatformAPI.Interfaces;
using MXPlatformAPI.Repositories;
using MXPlatformAPI.Responses;
using static MXPlatformAPI.Requests.RequestModels;

namespace MXPlatformAPI.Controllers
{
    public class InstitutionController : Controller
    {
        private readonly ILogger<InstitutionController> _logger;
        readonly string BaseUrl;
        public InstitutionController(ILogger<InstitutionController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            BaseUrl = iConfig.GetSection("ApiSettings").GetSection("BaseUrl").Value; ///Get base url from appsetting.json 
        }

        [HttpGet(nameof(ListInstitutions))]
        public async Task<ResponseMessage> ListInstitutions()
        {
            ResponseMessage _response = new();
            InstitutionRepository institutionRepository = new();
            try
            {
                var result = await institutionRepository.ListInstitutions(BaseUrl);
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "Institution list found.";
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "Institution list found!";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
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
                var result = await institutionRepository.GetInstituteCredential(InstituteCode, BaseUrl);
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
                _response.Status = false;
                _response.Message = ex.Message;
                return _response;
            }
            return _response;
        }
    }
}
