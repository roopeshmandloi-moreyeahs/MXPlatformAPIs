using MXPlatformAPI.Helper;
using MXPlatformAPI.Interfaces;
using MXPlatformAPI.Responses;
using RestSharp;
using System.Text.Json;
using static MXPlatformAPI.Requests.RequestModels;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MXPlatformAPI.Repositories
{
    public class UserRepository : IUserRepository
    {

     
        readonly string baseUrl;
        readonly IConfiguration _iConfig;

        public UserRepository(IConfiguration iConfig)
        {
            baseUrl = iConfig.GetSection("ApiSettings").GetSection("baseUrl").Value;
            _iConfig = iConfig;
        }

        /// <summary>
        /// CreateUser
        /// </summary>
        /// <param name="root"></param>
        /// <returns>User Guid</returns>
        public Task<ResponseMessage> CreateUser(Root root)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new(_iConfig);
            try
            {
                var options = new RestClientOptions(baseUrl + @"/users")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = header.Addheader("Post");/// Calling header helper class
                request.AddJsonBody(root);
                RestResponse res = client.Execute(request);
                if (res.IsSuccessStatusCode)
                {
                    if (res.Content != null)
                    {
                        _response.Status = true;
                        dataItem.JsonData = JsonSerializer.Deserialize<CreateUserResponse>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        _response.Status = false;
                        dataItem.JsonData = res;
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
        /// ListUser
        /// </summary>
        /// <returns>List of User </returns>
        public Task<ResponseMessage> ListUser()
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new(_iConfig);
            try
            {
                var options = new RestClientOptions(baseUrl + @"/users")
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
                        _response.Message = "User list found.";
                        dataItem.JsonData = dataItem.JsonData = JsonSerializer.Deserialize<ListUserResponse>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "User list not found!";
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
