using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MXPlatformAPI.Responses;
using RestSharp;
using System.Net;
using System.Text;
using System.Text.Json;
using static MXPlatformAPI.Requests.RequestModels;

namespace MXPlatformAPI.Controllers
{
    public class MXAPIController : Controller
    {
        private readonly ILogger<MXAPIController> _logger;


        public MXAPIController(ILogger<MXAPIController> logger)
        {
            _logger = logger;
        }

        //const string ClientId = "84c5fff0-09d4-45c9-be5a-12e6c78b160c";
        //const string APIKey = "4a575f252aa1edee0853ffdff8e1c659e7788c14";
        //const string BasicAuth = "ODRjNWZmZjAtMDlkNC00NWM5LWJlNWEtMTJlNmM3OGIxNjBjOjRhNTc1ZjI1MmFhMWVkZWUwODUzZmZkZmY4ZTFjNjU5ZTc3ODhjMTQ=";
        //const string BaseUrl = "https://int-api.mx.com";
        
        //[HttpPost(nameof(CreateUser))]
        //public async Task<ResponseMessage> CreateUser([FromBody] Root user)
        //{

            
        //    ResponseMessage _response = new();
        //    Data dataItem = new();
        //    try
        //    {
        //        var options = new RestClientOptions(BaseUrl+@"/users")
        //        {
        //            MaxTimeout = -1,
        //        };
        //        var client = new RestClient(options);
        //        var request = new RestRequest("", Method.Post);
        //        request.AddHeader("Content-Type", "application/json");
        //        request.AddHeader("Authorization", $"Basic {BasicAuth}");
        //        request.AddHeaders(new Dictionary<string, string> { { "Accept", "application/vnd.mx.api.v1+json" } });
        //        request.AddHeader("Cookie", "Cookie_1=value");
        //        request.AddJsonBody(user);
     
        //        RestResponse response = client.Execute(request);
        //        Console.WriteLine(response.Content);
        //        _response.Message = "User created.";
        //        _response.Status = true;
        //        dataItem.JsonData = response.Content;
        //        _response.Data = dataItem;
        //        return _response;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.Status = false;
        //        _response.Message = "User creation failed! " + ex.Message;
        //        return _response;
        //    }
        //}

      
    }
    }
