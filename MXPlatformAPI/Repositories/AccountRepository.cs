using MXPlatformAPI.Controllers;
using MXPlatformAPI.Helper;
using MXPlatformAPI.Interfaces;
using MXPlatformAPI.Responses;
using MXPlatformAPI.Validator.Interfaces;
using RestSharp;
using System.Text.Json;
namespace MXPlatformAPI.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        readonly string baseUrl;
        readonly IConfiguration _iConfig;
      
        public AccountRepository(IConfiguration iConfig)
        {
            baseUrl = iConfig.GetSection("ApiSettings").GetSection("baseUrl").Value;
            _iConfig = iConfig;

        }
        
        /// <summary>
        /// ListAccountData
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public Task<ResponseMessage> ListAccountData(string userGuid)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            
            try
            {
                var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + @"/accounts")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                HeaderHelperClass header = new(_iConfig);
                var request = header.Addheader("Get"); /// Calling header helper class

                RestResponse res = client.Execute(request);

                if (res.IsSuccessStatusCode)
                {
                    if (res.Content != null)
                    {
                        _response.Status = true;
                        _response.Message = "Account list found.";
                        dataItem.JsonData = JsonSerializer.Deserialize<dynamic>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "Account Data list not found!";
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
