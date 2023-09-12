using Microsoft.AspNetCore.Mvc;
using MXPlatformAPI.Repositories;
using MXPlatformAPI.Responses;
using MXPlatformAPI.Validator;
using System.Net;
using static MXPlatformAPI.Responses.ResponseNew;

namespace MXPlatformAPI.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;
        readonly IConfiguration _config;

        public TransactionController(ILogger<TransactionController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        [HttpGet(nameof(ListTransactionDataByAccountGuid))]
        public async Task<ResponseMessage> ListTransactionDataByAccountGuid(string userGuid, string accountGuid)
        {
            ResponseMessage _response = new();
            TransactionRepository _transactionRepository = new(_config);
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
                var result = await _transactionRepository.ListTransactionData(userGuid, accountGuid);
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
            TransactionRepository _transactionRepository = new(_config);
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
                var result = await _transactionRepository.ListTransactionDataByMember(userGuid, memberGuid);
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
            TransactionRepository _transactionRepository = new(_config);
            try
            {

                //userGuid validation
                if (string.IsNullOrEmpty(userGuid))
                {
                    _response.Status = false;
                    _response.Message = "Invalid User Guid!";
                    return _response;
                }

                var result = await _transactionRepository.ListTransactionDataByUserGuid(userGuid);
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
            TransactionRepository _transactionRepository = new(_config);
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
                var result = await _transactionRepository.ReadTransactionDataByTransactionGuid(userGuid, transactionGuid);
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

        [HttpGet(nameof(GetAggregatedDataByUserGuid))]
       
        public async Task<IActionResult> GetAggregatedDataByUserGuid(string userGuid)
        {
            ResponseMessage _response = new ResponseMessage();
            TransactionRepository _transactionRepository = new(_config);
            try
            {
                //userGuid validation
                if (string.IsNullOrEmpty(userGuid))
                {
                    _response.Status = false;
                    return NotFound($"Invalid UserID!");
                }
                else
                {
                    _response = await _transactionRepository.GetAggregatedDataByUserGuid(userGuid);
                    if (_response.Status)
                    {
                        _logger.LogInformation("Transaction Data found successfully.");
                        return Ok(_response.Data.JsonData);
                    }
                    else
                    {
                        _response.Status = false;
                        _logger.LogCritical("Transaction Data not found!");
                        return NotFound($"Aggregated data with UserID {userGuid} not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoggingAt:{date} RequestIdentifier:{api} Exception:{ex}", DateTime.Now, "transaction data", ex);
                _response.Status = false;
                var error = new { message = ex.Message }; //<-- anonymous object
                return BadRequest(error);
            }
            
        }















    }
}
