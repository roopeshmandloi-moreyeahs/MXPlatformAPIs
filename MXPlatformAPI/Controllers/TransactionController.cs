using Microsoft.AspNetCore.Mvc;
using MXPlatformAPI.Repositories;
using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;
        readonly string? baseUrl;
        /// <summary>
        /// Basic Auth for Anutenticating the MAX Platform API's
        /// </summary>
        readonly string? basicAuth;

        public TransactionController(ILogger<TransactionController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            baseUrl = iConfig.GetSection("ApiSettings").GetSection("baseUrl").Value; ///Get base url from appsetting.json 
            basicAuth = iConfig.GetSection("ApiSettings").GetSection("basicAuth").Value; ///Get Basic Auth from appsetting.json 
        }

        [HttpGet(nameof(ListTransactionDataByAccountGuid))]
        public async Task<ResponseMessage> ListTransactionDataByAccountGuid(string UserGuid, string AccountGuid)
        {
            ResponseMessage _response = new();
            TransactionRepository TransactionRepository = new();
            try
            {
                //UserGuid validation
                if(string.IsNullOrEmpty(UserGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid User Guid!";
                    return _response;
                }
                //AccountGuid validation 
                if (string.IsNullOrEmpty(AccountGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid Account Guid!";
                    return _response;
                }
                var result = await TransactionRepository.ListTransactionData(UserGuid, AccountGuid,baseUrl, basicAuth);
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "Transaction Data found.";
                    _logger.LogInformation("Transaction Data found successfully.");
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "Transaction Data not found!";
                    _logger.LogCritical("Transaction Data not found!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoggingAt:{date} RequestIdentifier:{api} Exception:{ex}", DateTime.Now, "transaction data", ex);
                _response.Status = false;
                _response.Message = ex.Message;
                return _response;
            }
            return _response;
        }
        
        [HttpGet(nameof(ListTransactionDataByMemberGuid))]
        public async Task<ResponseMessage> ListTransactionDataByMemberGuid(string UserGuid, string MemberGuid)
        {
            ResponseMessage _response = new();
            TransactionRepository TransactionRepository = new();
            try
            {

                if (string.IsNullOrEmpty(UserGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid User Guid!";
                    return _response;
                }
                //MemberGuid validation 
                if (string.IsNullOrEmpty(MemberGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid Member Guid!";
                    return _response;
                }
                var result = await TransactionRepository.ListTransactionDataByMember(UserGuid, MemberGuid, baseUrl, basicAuth);
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "Transaction Data found.";
                    _logger.LogInformation("Transaction Data found successfully.");
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "Transaction Data not found!";
                    _logger.LogCritical("Transaction Data not found!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoggingAt:{date} RequestIdentifier:{api} Exception:{ex}", DateTime.Now, "transaction data", ex);
                _response.Status = false;
                _response.Message = ex.Message;
                return _response;
            }
            return _response;
        }

        [HttpGet(nameof(ListTransactionDataByUserGuid))]
        public async Task<ResponseMessage> ListTransactionDataByUserGuid(string UserGuid)
        {
            ResponseMessage _response = new();
            TransactionRepository TransactionRepository = new();
            try
            {

                //UserGuid validation
                if (string.IsNullOrEmpty(UserGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid User Guid!";
                    return _response;
                }
                
                var result = await TransactionRepository.ListTransactionDataByUserGuid(UserGuid, baseUrl, basicAuth);
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "Transaction Data found.";
                    _logger.LogInformation("Transaction Data found successfully.");
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "Transaction Data not found!";
                    _logger.LogCritical("Transaction Data not found!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoggingAt:{date} RequestIdentifier:{api} Exception:{ex}", DateTime.Now, "transaction data", ex);
                _response.Status = false;
                _response.Message = ex.Message;
                return _response;
            }
            return _response;
        }

        [HttpGet(nameof(GetTransactionDetailByTransactionGuid))]
        public async Task<ResponseMessage> GetTransactionDetailByTransactionGuid(string UserGuid, string TransactionGuid)
        {
            ResponseMessage _response = new();
            TransactionRepository TransactionRepository = new();
            try
            {

                if (string.IsNullOrEmpty(UserGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid User Guid!";
                    return _response;
                }
                //TransactionGuid validation 
                if (string.IsNullOrEmpty(TransactionGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid Transaction Guid!";
                    return _response;
                }
                var result = await TransactionRepository.ReadTransactionDataByTransactionGuid(UserGuid, TransactionGuid, baseUrl, basicAuth);
                if (result.Status)
                {
                    _response.Data = result.Data;
                    _response.Status = true;
                    _response.Message = "Transaction Detail found.";
                    _logger.LogInformation("Transaction Detail found successfully.");
                }
                else
                {
                    _response.Data = result.Data;
                    _response.Status = false;
                    _response.Message = "Transaction Detail not found!";
                    _logger.LogCritical("Transaction Detail not found!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoggingAt:{date} RequestIdentifier:{api} Exception:{ex}", DateTime.Now, "transaction data", ex);
                _response.Status = false;
                _response.Message = ex.Message;
                return _response;
            }
            return _response;
        }
    }
}
