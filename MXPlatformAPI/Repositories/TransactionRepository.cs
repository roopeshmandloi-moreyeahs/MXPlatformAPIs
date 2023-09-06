using Microsoft.AspNetCore.Mvc;
using MXPlatformAPI.Helper;
using MXPlatformAPI.Interfaces;
using MXPlatformAPI.Responses;
using Newtonsoft.Json;
using RestSharp;
using System.Security.Policy;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Transaction = MXPlatformAPI.Responses.ResponseNew.Transaction;

namespace MXPlatformAPI.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        readonly IConfiguration _iConfig;

        readonly string baseUrl;

        public TransactionRepository(IConfiguration iConfig)
        {
            baseUrl = iConfig.GetSection("ApiSettings").GetSection("baseUrl").Value;
            _iConfig = iConfig;
        }

        /// <summary>
        /// ListTransactionData
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="accountGuid"></param>
        /// <returns>List of Transaction Data</returns>
        public Task<ResponseMessage> ListTransactionData(string userGuid, string accountGuid)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new(_iConfig);
            try
            {

                var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + @"/accounts/" + accountGuid + @"/transactions")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);

                var request = header.Addheader("Get"); /// Calling header helper class

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
        /// <returns>List of Transaction Data</returns>
        public Task<ResponseMessage> ListTransactionDataByMember(string userGuid, string memberGuid)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new(_iConfig);
            try
            {

                var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + @"/members/" + memberGuid + @"/transactions")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);

                var request = header.Addheader("Get"); /// Calling header helper class

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
        /// <returns>List of Transaction Data</returns>
        public Task<ResponseMessage> ListTransactionDataByUserGuid(string userGuid)
        {
            ResponseMessage _response = new();
            ResponseNew _responseNew = new();
            Data dataItem = new();
            HeaderHelperClass header = new(_iConfig);
            try
            {

                var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + @"/transactions")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);

                var request = header.Addheader("Get"); /// Calling header helper class

                RestResponse res = client.Execute(request);

                if (res.IsSuccessStatusCode)
                {
                    if (res.Content != null)                                                                                            
                    {

                        dataItem.JsonData = JsonSerializer.Deserialize<dynamic>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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
        /// Get Aggregated Transaction Data By User Guid
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns>List of Transaction Data</returns>

        public async Task<ResponseMessage> GetAggregatedDataByUserGuid(string userGuid)
        {
            ResponseMessage _response = new();
            List<ResponseNew.Institution> institution = new();
            List<ResponseNew.Account> accList = new();
            
            Data dataItem = new();
            HelperDTO.RootResponse root = new();
            HelperDTO.RootObject _rootTrans = new();
            HeaderHelperClass header = new(_iConfig);
            ResponseNew.ResponseRoot _root = new();
            try
            {
                var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + "/accounts")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = header.Addheader("Get"); /// Calling header helper class

                RestResponse res = client.Execute(request);
                #region
                if (res.IsSuccessStatusCode)
                {
                    if (res.Content != null)
                    {
                        root = JsonSerializer.Deserialize<HelperDTO.RootResponse>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        var instituteData = root.Accounts.DistinctBy(d => new { d.InstitutionCode });
                        var instituteSelected = instituteData.Select(g => new
                        {
                            g.InstitutionCode
                            // Add more properties as needed...
                        });
                        foreach (var item in instituteSelected)
                        {
                            var acccountFiltered = root.Accounts.Where(x => x.InstitutionCode == item.InstitutionCode).ToList();
                            foreach (var acc in acccountFiltered)
                            {
                                List<ResponseNew.Transaction> transList = new();
                                var optionTransaction = new RestClientOptions(baseUrl + @"/users/" + userGuid + "/accounts/" + acc.Guid + "/transactions")
                                {
                                    MaxTimeout = -1,
                                };
                                var clientNew = new RestClient(optionTransaction);
                                var requestNew = header.Addheader("Get"); /// Calling header helper class
                                RestResponse resNew = clientNew.Execute(requestNew);
                                if (resNew.IsSuccessStatusCode)
                                {
                                    if (resNew.Content != null)
                                    {
                                        _rootTrans = JsonConvert.DeserializeObject<HelperDTO.RootObject>(resNew.Content);

                                        foreach (var trans in _rootTrans.Transactions)
                                        {
                                            transList.Add(new Transaction { ExternalTransactionId = trans.Guid, Amount = trans.Amount, Date = trans.Date, Description = trans.Description });
                                        }
                                    }
                                }

                                accList.Add(new ResponseNew.Account
                                {
                                    AccountNumber = acc.AccountNumber,
                                    AccountType = acc.Type,
                                    CurrencyCode = acc.CurrencyCode,
                                    ExternalAccountId = acc.Guid,
                                    DataSourceId = acc.Id,
                                    AvailableBalance = acc.AvailableBalance.ToString(),
                                    CurrentBalance = acc.Balance.ToString(),
                                    Transactions = transList
                                });
                            }
                            institution.Add(new ResponseNew.Institution { Name = item.InstitutionCode, Accounts = accList });
                            _root.Institutions = institution;
                            dataItem.JsonData =  JsonConvert.SerializeObject(_root);
                            _response.Data = dataItem;
                        }
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "Transaction Data not found!";
                    }
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Transaction Data not found!";
                }
                _response.Status = true;
                _response.Message = "Transaction data found!";
                #endregion
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
            }



            return _response;
        }


        /// <summary>
        /// ReadTransactionDataByTransactionGuid
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="transactionGuid"></param>
        /// <returns>Transaction Data detail</returns>
        public Task<ResponseMessage> ReadTransactionDataByTransactionGuid(string userGuid, string transactionGuid)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new(_iConfig);
            try
            {

                var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + @"/transactions/" + transactionGuid)
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);

                var request = header.Addheader("Get"); /// Calling header helper class

                RestResponse res = client.Execute(request);

                if (res.IsSuccessStatusCode)
                {
                    if (res.Content != null)
                    {
                        _response.Status = true;
                        _response.Message = "Transaction Detail found.";
                        dataItem.JsonData = JsonSerializer.Deserialize<dynamic>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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
