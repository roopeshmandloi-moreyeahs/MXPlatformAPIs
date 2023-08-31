using MXPlatformAPI.Helper;
using MXPlatformAPI.Interfaces;
using MXPlatformAPI.Responses;
using RestSharp;
using System.Text.Json;

namespace MXPlatformAPI.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        /// <summary>
        /// ListTransactionData
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="accountGuid"></param>
        /// <param name="baseUrl"></param>
        /// <param name="basicAuth"></param>
        /// <returns>List of Transaction Data</returns>
        public Task<ResponseMessage> ListTransactionData(string userGuid, string accountGuid, string baseUrl, string basicAuth)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new();
            try
            {

                var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + @"/accounts/" + accountGuid + @"/transactions")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);

                var request = header.Addheader("Get", basicAuth); /// Calling header helper class

                RestResponse res = client.Execute(request);

                if (res.IsSuccessStatusCode)
                {
                    if (res.Content != null)
                    {
                        _response.Status = true;
                        _response.Message = "Transaction Data found.";
                        dataItem.JsonData = dataItem.JsonData = JsonSerializer.Deserialize<dynamic>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "Transaction Data not found!";
                    }
                    _response.Data = dataItem;
                }
                else
                {
                    _response.Status = false;
                }
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
            }
            return Task.FromResult(_response);
        }

        /// <summary>
        /// ListTransactionDataByMember
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="memberGuid"></param>
        /// <param name="baseUrl"></param>
        /// <param name="basicAuth"></param>
        /// <returns>List of Transaction Data</returns>
        public Task<ResponseMessage> ListTransactionDataByMember(string userGuid, string memberGuid, string baseUrl, string basicAuth)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new();
            try
            {

                var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + @"/members/" + memberGuid + @"/transactions")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);

                var request = header.Addheader("Get", basicAuth); /// Calling header helper class

                RestResponse res = client.Execute(request);

                if (res.IsSuccessStatusCode)
                {
                    if (res.Content != null)
                    {
                        _response.Status = true;
                        _response.Message = "Transaction Data found.";
                        dataItem.JsonData = dataItem.JsonData = JsonSerializer.Deserialize<dynamic>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "Transaction Data not found!";
                    }
                    _response.Data = dataItem;
                }
                else
                {
                    _response.Status = false;
                }
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
            }
            return Task.FromResult(_response);
        }

        /// <summary>
        /// ListTransactionDataByUserGuid
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="baseUrl"></param>
        /// <param name="basicAuth"></param>
        /// <returns>List of Transaction Data</returns>
        public Task<ResponseMessage> ListTransactionDataByUserGuid(string userGuid, string baseUrl, string basicAuth)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new();
            try
            {

                var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + @"/transactions")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);

                var request = header.Addheader("Get", basicAuth); /// Calling header helper class

                RestResponse res = client.Execute(request);

                if (res.IsSuccessStatusCode)
                {
                    if (res.Content != null)
                    {
                        _response.Status = true;
                        _response.Message = "Transaction Data found.";
                        dataItem.JsonData = dataItem.JsonData = JsonSerializer.Deserialize<dynamic>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "Transaction Data not found!";
                    }
                    _response.Data = dataItem;
                }
                else
                {
                    _response.Status = false;
                }
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
            }
            return Task.FromResult(_response);
        }

        /// <summary>
        /// ReadTransactionDataByTransactionGuid
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="transactionGuid"></param>
        /// <param name="baseUrl"></param>
        /// <param name="basicAuth"></param>
        /// <returns>Transaction Data detail</returns>
        public Task<ResponseMessage> ReadTransactionDataByTransactionGuid(string userGuid, string transactionGuid, string baseUrl, string basicAuth)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new();
            try
            {

                var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + @"/transactions/" + transactionGuid)
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);

                var request = header.Addheader("Get", basicAuth); /// Calling header helper class

                RestResponse res = client.Execute(request);

                if (res.IsSuccessStatusCode)
                {
                    if (res.Content != null)
                    {
                        _response.Status = true;
                        _response.Message = "Transaction Detail found.";
                        dataItem.JsonData = dataItem.JsonData = JsonSerializer.Deserialize<dynamic>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "Transaction Detail not found!";
                    }
                    _response.Data = dataItem;
                }
                else
                {
                    _response.Status = false;
                }
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
            }
            return Task.FromResult(_response);
        }
    }
}
