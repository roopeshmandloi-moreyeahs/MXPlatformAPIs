using Microsoft.AspNetCore.Mvc;
using MXPlatformAPI.Repositories;
using MXPlatformAPI.Responses;
using MXPlatformAPI.Validator;
using MXPlatformAPI.Validator.Interfaces;
using static MXPlatformAPI.Requests.RequestModels;

namespace MXPlatformAPI.Controllers
{
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;
        private readonly IMemberValidation _validation;
        readonly string? BaseUrl;
        public MemberController(IConfiguration iConfig, ILogger<MemberController> logger, IMemberValidation validation)
        {
            BaseUrl = iConfig.GetSection("ApiSettings").GetSection("BaseUrl").Value;
            _logger = logger;
            _validation = validation;
        }

        /// <summary>
        /// Create Member 
        /// </summary>
        /// <param name="member"></param>
        /// <returns>user_guid</returns>
        [HttpPost(nameof(CreateMember))]
        public async Task<ResponseMessage> CreateMember([FromBody] CreateMemberRoot member, string UserGuid)
        {
            ResponseMessage _response = new();
            Data data = new();
            MemberRepository MemberRepository = new();
            ErrorResponse? errorResponse;
            try
            {
                #region Validate Request Model
                if(string.IsNullOrEmpty(UserGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid User Guid!";
                    return _response;
                }
                var validation = await _validation.CreateMemberValidator.ValidateAsync(member);
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
                var result = await MemberRepository.CreateMember(member, UserGuid, BaseUrl);
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "Member created.";
                    _logger.LogInformation("Member created successfully.");
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "Member not created.";
                    _logger.LogCritical("Member not created!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoggingAt:{date} RequestIdentifier:{api} Exception:{ex}", DateTime.Now, "create member", ex);
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
        [HttpGet(nameof(ListMembers))]
        public async Task<ResponseMessage> ListMembers(string UserGuid)
        {
            ResponseMessage _response = new();
            MemberRepository MemberRepository = new();
            try
            {
                var result = await MemberRepository.ListMembers(UserGuid, BaseUrl);
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "Member list found.";
                    _logger.LogInformation("Member list found successfully.");
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "Member list not found!";
                    _logger.LogCritical("Member list not found!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoggingAt:{date} RequestIdentifier:{api} Exception:{ex}", DateTime.Now, "member list", ex);
                _response.Status = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        /// <summary>
        /// List users
        /// </summary>
        /// <param></param>
        /// <returns>list of users</returns>
        [HttpGet(nameof(CheckMemberStatus))]
        public async Task<ResponseMessage> CheckMemberStatus(string UserGuid, string MemberGuid)
        {
            ResponseMessage _response = new();
            MemberRepository MemberRepository = new();
            try
            {
                var result = await MemberRepository.CheckMemberStatus(UserGuid, MemberGuid, BaseUrl);
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "Member status found.";
                    _logger.LogInformation("Member status found successfully.");
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "Member status not found!";
                    _logger.LogCritical("Member status not found!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoggingAt:{date} RequestIdentifier:{api} Exception:{ex}", DateTime.Now, "Member status", ex);
                _response.Status = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
