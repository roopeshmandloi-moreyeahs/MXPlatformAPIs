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
    public class TransactionRepositoryNew : ITransactionRepositoryTest
    {
        
        /// <summary>
        /// Get Aggregated Transaction Data By User Guid
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="baseUrl"></param>
        /// <param name="basicAuth"></param>
        /// <returns>List of Transaction Data</returns>

        public async Task<ResponseMessage> GetAggregatedDataByUserGuidTest(string userGuid, string baseUrl, string basicAuth)
        {
            ResponseMessage _response = new();
            List<ResponseNew.Institution> institution = new();
            List<ResponseNew.Account> accList = new();
            
            DataNew dataItemNew = new();
            HelperDTO.Root account = new();
            HelperDTO.Transaction transaction = new();
            HelperDTO.RootObject _rootTrans = new();
            HeaderHelperClass header = new();
            ResponseNew.Root _root = new();
            try
            {
                var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + "/accounts")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = header.Addheader("Get", basicAuth); /// Calling header helper class

                RestResponse res = client.Execute(request);
                #region
                if (res.IsSuccessStatusCode)
                {
                    if (res.Content != null)
                    {
                        account = JsonSerializer.Deserialize<HelperDTO.Root>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        var instituteData = account.Accounts.DistinctBy(d => new { d.InstitutionCode });
                        var instituteSelected = instituteData.Select(g => new
                        {
                            g.InstitutionCode
                            // Add more properties as needed...
                        });
                        foreach (var item in instituteSelected)
                        {
                            var acccountFiltered = account.Accounts.Where(x => x.InstitutionCode == item.InstitutionCode).ToList();
                            foreach (var acc in acccountFiltered)
                            {
                                List<ResponseNew.Transaction> transList = new();
                                var optionTransaction = new RestClientOptions(baseUrl + @"/users/" + userGuid + "/accounts/" + acc.Guid + "/transactions")
                                {
                                    MaxTimeout = -1,
                                };
                                var clientNew = new RestClient(optionTransaction);
                                var requestNew = header.Addheader("Get", basicAuth); /// Calling header helper class
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
                           
                            //var accdata = new Dictionary<string, object>{
                            //    { "Accounts", accList
                            //      }
                            //      };
                            var responseData = new Dictionary<string, object>
                                {
                                    { "Name", item.InstitutionCode }
                              };
                            // Add more key-value pairs as needed

                            institution.Add(new ResponseNew.Institution { Name = item.InstitutionCode, Accounts = accList });
                            Console.WriteLine(JsonConvert.SerializeObject(institution.ToList()));
                            var resp = JsonConvert.SerializeObject(institution.ToList());
                            dataItemNew.JsonDataNew = resp.Trim();

                           dynamic test = JsonConvert.DeserializeObject<dynamic>(resp);

                            string name = test.Name;

                           //foreach(var t in test)
                           // {
                           //     accList.Add(new ResponseNew.Account
                           //     {
                           //         AccountNumber = t["Accounts"].AccountNumber,
                           //         AccountType = t["Accounts"].Type,
                           //         CurrencyCode = t["Accounts"].CurrencyCode,
                           //         ExternalAccountId = t["Accounts"].Guid,
                           //         DataSourceId = t["Accounts"].Id,
                           //         AvailableBalance = t["Accounts"].AvailableBalance.ToString(),
                           //         CurrentBalance = t["Accounts"].Balance.ToString(),
                           //     });
                           //     //institution.Add(new ResponseNew.Institution { Name = t["Name"].InstitutionCode, Accounts = accList });
                           // }
                          

                            dataItemNew.JsonDataNew = test;
                            _response.dataNew = dataItemNew;
                            //return _response;
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
                //_root.Institutions = institution.ToList();
                //dataItemNew.JsonDataNew = _root;
                //_response.dataNew = dataItemNew;
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

    }
}
