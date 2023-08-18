using RestSharp;
using static MXPlatformAPI.Requests.RequestModels;

namespace MXPlatformAPI.Helper
{
    public class HeaderHelperClass
    {
        const string BasicAuth = @"ODRjNWZmZjAtMDlkNC00NWM5LWJlNWEtMTJlNmM3OGIxNjBjOjRhNTc1ZjI1MmFhMWVkZWUwODUzZmZkZmY4ZTFjNjU5ZTc3ODhjMTQ=";

        /// <summary>
        /// Header Method 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public RestRequest Addheader(string methodstring)
        {
            RestRequest request = new();
            if (methodstring== "Post")
            {
                request = new RestRequest("", Method.Post);
            } 
            if(methodstring== "Put")
            {
                request = new RestRequest("", Method.Put);
            }
            if (methodstring == "Delete")
            {
                request = new RestRequest("", Method.Delete);
            }
            if (methodstring == "Get")
            {
                request = new RestRequest("", Method.Get); 
            }
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Basic {BasicAuth}");
            request.AddHeaders(new Dictionary<string, string> { { "Accept", "application/vnd.mx.api.v1+json" } });
            request.AddHeader("Cookie", "Cookie_1=value");
            return request;
        }
    }
}
