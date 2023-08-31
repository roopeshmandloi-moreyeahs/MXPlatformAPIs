using MXPlatformAPI.Controllers;
using RestSharp;

namespace MXPlatformAPI.Helper
{
    public class HeaderHelperClass
    {
        
        /// <summary>
        /// Header Method 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public RestRequest Addheader(string methodstring,string basicAuth)
        {
            RestRequest request = new();
            if (methodstring == "Post")
            {
                request = new RestRequest("", Method.Post);
            }
            if (methodstring == "Put")
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
            request.AddHeader("Authorization", $"Basic {basicAuth}");
            request.AddHeaders(new Dictionary<string, string> { { "Accept", "application/vnd.mx.api.v1+json" } });
            request.AddHeader("Cookie", "Cookie_1=value");
            return request;
        }
    }
}
