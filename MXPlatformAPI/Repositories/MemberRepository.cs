using MXPlatformAPI.Helper;
using MXPlatformAPI.Interfaces;
using MXPlatformAPI.Responses;
using RestSharp;
using System.Text.Json;
using static MXPlatformAPI.Requests.RequestModels;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MXPlatformAPI.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        readonly IConfiguration _iConfig;
       
  
        readonly string baseUrl;
       
        public MemberRepository(IConfiguration iConfig)
        {
            baseUrl = iConfig.GetSection("ApiSettings").GetSection("baseUrl").Value;
            _iConfig = iConfig;
        }
        /// <summary>
        /// CreateMember
        /// </summary>
        /// <param name="root"></param>
        /// <param name="userGuid"></param>
        /// <returns>Member Guid</returns>
        public Task<ResponseMessage> CreateMember(CreateMemberRoot root, string userGuid)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new(_iConfig);
            try
            {

                var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + @"/members")
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
                        dataItem.JsonData = JsonSerializer.Deserialize<dynamic>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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
        /// CheckMemberStatus
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="memberGuid"></param>
        /// <returns>Member Status</returns>
        public Task<ResponseMessage> CheckMemberStatus(string userGuid, string memberGuid)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new(_iConfig);
            try
            {
                var options = new RestClientOptions(baseUrl + @"/users/" + @userGuid + "/members/" + @memberGuid + "/status")
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
                        _response.Message = "Member status found.";
                        dataItem.JsonData = dataItem.JsonData = JsonSerializer.Deserialize<dynamic>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "Member status not found!";
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
        /// ListMembers
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns>Members List</returns>
        public Task<ResponseMessage> ListMembers(string userGuid)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new(_iConfig);
            try
            {
                var options = new RestClientOptions(baseUrl + @"/users/" + userGuid + "/members")
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
                        _response.Message = "Members list found.";
                        dataItem.JsonData = dataItem.JsonData = JsonSerializer.Deserialize<dynamic>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "Members list not found!";
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
