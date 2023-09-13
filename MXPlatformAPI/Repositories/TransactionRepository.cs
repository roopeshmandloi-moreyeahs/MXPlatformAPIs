using Microsoft.AspNetCore.Mvc;
using MXPlatformAPI.Helper;
using MXPlatformAPI.Interfaces;
using MXPlatformAPI.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Reflection.PortableExecutable;
using System.Security.Policy;
using System.Text.Json;
using static MXPlatformAPI.Responses.HelperDTO;
using static MXPlatformAPI.Responses.ResponseNew;
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
            ResponseNew.ConsumerInformation _consumer = new();
            Data dataItem = new();
            Data dataItemConsumer = new();

            HeaderHelperClass header = new(_iConfig);
            ResponseRoot _root = new();
            try
            {
                #region Consumer Information
                var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + "/members")//API calling for getting accounts by userguid
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = header.Addheader("Get"); /// Calling header helper class

                RestResponse responseMember = client.Execute(request);
                if (responseMember.IsSuccessStatusCode)
                {
                    if (responseMember.Content != null)
                    {
                        AccountOwnerRoot ItemConsumer = CreateJsonMethodForConsumerInformation(responseMember.Content, userGuid);//Separate method for logic
                        if (ItemConsumer.AccountOwners.Count > 0)
                        {
                            
                            List<string> Email = new();
                            Email.Add(ItemConsumer.AccountOwners[0].Email);
                            _consumer.Email = Email;    
                            _consumer.FirstName = (string?)ItemConsumer.AccountOwners[0].FirstName;
                            _consumer.LastName = (string?)ItemConsumer.AccountOwners[0].LastName;
                            _consumer.FullName = (string?)ItemConsumer.AccountOwners[0].OwnerName;
                            _consumer.PhoneNumber = (string?)ItemConsumer.AccountOwners[0].Phone;
                            Address address = new Address();
                            address.Street= (string?)ItemConsumer.AccountOwners[0].Address;
                            address.City = (string?)ItemConsumer.AccountOwners[0].City;
                            address.Country = (string?)ItemConsumer.AccountOwners[0].Country;
                            address.PostalCode = (string?)ItemConsumer.AccountOwners[0].PostalCode;
                            address.Region = (string?)ItemConsumer.AccountOwners[0].State;

                            _consumer.Address = address;

                        }

                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "Transaction Data not found!";
                    }
                }
                #endregion Consumer Information

                options = new RestClientOptions(baseUrl + @"/users/" + userGuid + "/accounts")//API calling for getting accounts by userguid
                {
                    MaxTimeout = -1,
                };
                client = new RestClient(options);
                request = header.Addheader("Get"); /// Calling header helper class

                RestResponse res = client.Execute(request);
                #region
                if (res.IsSuccessStatusCode)
                {
                    if (res.Content != null)
                    {
                        dataItem = CreateJsonMethod(res.Content, userGuid, _consumer);//Seprate method for logic
                        
                        _response.Data = dataItem;
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
                    return _response;
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


        /// <summary>
        /// Method for modify a response
        /// </summary>
        /// <param name="result"></param>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public Data CreateJsonMethod(string result, string userGuid, ResponseNew.ConsumerInformation consumerInformation)
        {

            List<Institution> institution = new();
            List<ResponseNew.Account> accList = new();

            Data dataItem = new();
            HelperDTO.RootResponse _apiResponse = new();
            HelperDTO.RootObject _transactionApiResponse = new();
            HeaderHelperClass header = new(_iConfig);
            ResponseRoot _response = new();
            _apiResponse = JsonSerializer.Deserialize<HelperDTO.RootResponse>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var instituteData = _apiResponse.Accounts.DistinctBy(d => new { d.InstitutionCode });

            var instituteSelected = instituteData.Select(g => new
            {
                g.InstitutionCode
            });
            foreach (var item in instituteSelected)
            {
                var acccountFiltered = _apiResponse.Accounts.Where(x => x.InstitutionCode == item.InstitutionCode).ToList();
                foreach (var acc in acccountFiltered)
                {
                    List<Transaction> transList = new();
                    var optionTransaction = new RestClientOptions(baseUrl + @"/users/" + userGuid + "/accounts/" + acc.Guid + "/transactions")//API calling for getting transactions by Userguid & accountguid
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
                            _transactionApiResponse = JsonConvert.DeserializeObject<HelperDTO.RootObject>(resNew.Content);

                            foreach (var trans in _transactionApiResponse.Transactions)
                            {
                                Transaction trL = new();
                                trL.ExternalTransactionId = trans.Guid;
                                trL.Amount = trans.Amount;
                                trL.Date = trans.Date;
                                trL.Description = trans.Description;
                                transList.Add(trL);
                            }
                        }
                    }
                    ResponseNew.Account _account = new();
                    _account.AccountNumber = acc.AccountNumber;
                    _account.AccountType = acc.Type;
                    _account.CurrencyCode = acc.CurrencyCode;
                    _account.ExternalAccountId = acc.Guid;
                    _account.DataSourceId = acc.Id;
                    _account.AvailableBalance = acc.AvailableBalance.ToString();
                    _account.CurrentBalance = acc.Balance.ToString();
                    _account.Transactions = transList;
                    accList.Add(_account);
                }

                Institution _ins = new Institution();
                _ins.Name = item.InstitutionCode;
                _ins.Accounts = accList;
                institution.Add(_ins);
            }
            _response.Institutions = institution;
            _response.ConsumerInformation = consumerInformation;
            string _rootstring = JsonConvert.SerializeObject(_response);
            dataItem.JsonData = JsonSerializer.Deserialize<dynamic>(_rootstring, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return dataItem;
        }
        public AccountOwnerRoot CreateJsonMethodForConsumerInformation(string result, string userGuid)
        {

            List<ConsumerInformation> consumerInformation = new();

            Data dataItem = new();
            Data dataItemConsumer = new();
            HelperDTO.RootResponseMember _apiResponseMember = new();
            HelperDTO.AccountOwnerRoot accountOwnerRoot = new();
            HeaderHelperClass header = new(_iConfig);
            ResponseRoot _response = new();
            try
            {
                _apiResponseMember = JsonSerializer.Deserialize<HelperDTO.RootResponseMember>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var memberData = _apiResponseMember.Members.FirstOrDefault();

                if (memberData != null)
                {
                    //MBR-bfaec7a6-c300-419f-ab89-86b1cad5c283 --- Only member id that providing consumer information.
                    //Uncomment following line after testing done for production environment. Also comment line no. 439. 
                    //var options = new RestClientOptions(baseUrl + @"/users/"+userGuid+"/members/"+ memberData.Guid + "/account_owners")//API calling for getting accounts owner information by userguid
                    var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + "/members/MBR-bfaec7a6-c300-419f-ab89-86b1cad5c283" + "/account_owners")//API calling for getting accounts owner information by userguid
                    {
                        MaxTimeout = -1,
                    };
                    var client = new RestClient(options);
                    var request = header.Addheader("Get"); /// Calling header helper class

                    RestResponse responseMember = client.Execute(request);
                    if (responseMember.IsSuccessStatusCode)
                    {
                        if (responseMember.Content != null)
                        {
                            accountOwnerRoot = JsonSerializer.Deserialize<HelperDTO.AccountOwnerRoot>(responseMember.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        }
                        else
                        {
                            accountOwnerRoot = null;
                        }
                    }
                }

                return accountOwnerRoot;
            }
            catch
            {
                return null;
            }
        }
    }
}
