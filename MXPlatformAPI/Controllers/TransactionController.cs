using Microsoft.AspNetCore.Mvc;
using MXPlatformAPI.Repositories;
using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly string? baseUrl;
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
        public async Task<ResponseMessage> ListTransactionDataByAccountGuid(string userGuid, string accountGuid)
        {
            ResponseMessage _response = new();
            TransactionRepository _transactionRepository = new();
            try
            {
                //userGuid validation
                if (string.IsNullOrEmpty(userGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid User Guid!";
                    return _response;
                }
                //accountGuid validation 
                if (string.IsNullOrEmpty(accountGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid Account Guid!";
                    return _response;
                }
                var result = await _transactionRepository.ListTransactionData(userGuid, accountGuid, baseUrl, basicAuth);
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
        public async Task<ResponseMessage> ListTransactionDataByMemberGuid(string userGuid, string memberGuid)
        {
            ResponseMessage _response = new();
            TransactionRepository _transactionRepository = new();
            try
            {

                if (string.IsNullOrEmpty(userGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid User Guid!";
                    return _response;
                }
                //memberGuid validation 
                if (string.IsNullOrEmpty(memberGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid Member Guid!";
                    return _response;
                }
                var result = await _transactionRepository.ListTransactionDataByMember(userGuid, memberGuid, baseUrl, basicAuth);
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
        public async Task<ResponseMessage> ListTransactionDataByUserGuid(string userGuid)
        {
            ResponseMessage _response = new();
            TransactionRepository _transactionRepository = new();
            try
            {

                //userGuid validation
                if (string.IsNullOrEmpty(userGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid User Guid!";
                    return _response;
                }

                var result = await _transactionRepository.ListTransactionDataByUserGuid(userGuid, baseUrl, basicAuth);
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
        public async Task<ResponseMessage> GetTransactionDetailByTransactionGuid(string userGuid, string transactionGuid)
        {
            ResponseMessage _response = new();
            TransactionRepository _transactionRepository = new();
            try
            {

                if (string.IsNullOrEmpty(userGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid User Guid!";
                    return _response;
                }
                //transactionGuid validation 
                if (string.IsNullOrEmpty(transactionGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid Transaction Guid!";
                    return _response;
                }
                var result = await _transactionRepository.ReadTransactionDataByTransactionGuid(userGuid, transactionGuid, baseUrl, basicAuth);
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
