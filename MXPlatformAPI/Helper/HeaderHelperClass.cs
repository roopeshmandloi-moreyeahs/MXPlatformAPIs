using RestSharp;

namespace MXPlatformAPI.Helper
{
    public class HeaderHelperClass
    {

        /// <summary>
        /// Addheader
        /// </summary>
        /// <param name="methodString"></param>
        /// <param name="basicAuth"></param>
        /// <returns>_request</returns>
        public RestRequest Addheader(string methodString, string basicAuth)
        {
            RestRequest _request = new();
            if (methodString == "Post")
            {
                _request = new RestRequest("", Method.Post);
            }
            if (methodString == "Put")
            {
                _request = new RestRequest("", Method.Put);
            }
            if (methodString == "Delete")
            {
                _request = new RestRequest("", Method.Delete);
            }
            if (methodString == "Get")
            {
                _request = new RestRequest("", Method.Get);
            }
            _request.AddHeader("Content-Type", "application/json");
            _request.AddHeader("Authorization", $"Basic {basicAuth}");
            _request.AddHeaders(new Dictionary<string, string> { { "Accept", "application/vnd.mx.api.v1+json" } });
            _request.AddHeader("Cookie", "Cookie_1=value");
            return _request;
        }
    }
}
