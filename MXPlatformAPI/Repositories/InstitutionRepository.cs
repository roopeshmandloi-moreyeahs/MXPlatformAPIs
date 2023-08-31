using MXPlatformAPI.Helper;
using MXPlatformAPI.Interfaces;
using MXPlatformAPI.Responses;
using RestSharp;
using System.Text.Json;
namespace MXPlatformAPI.Repositories
{
    public class InstitutionRepository : IInstitutionRepository
    {

        /// <summary>
        /// ListInstitutions
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="basicAuth"></param>
        /// <returns>Institution list</returns>
        public Task<ResponseMessage> ListInstitutions(string baseUrl,string basicAuth)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new();
            try
            {
                var options = new RestClientOptions(baseUrl + @"/institutions")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);

                var request = header.Addheader("Get", basicAuth); /// Calling header helper class

                RestResponse res = client.Execute(request);

                if (res.IsSuccessStatusCode)
                {
                    if (res.Content != null)
                    {
                        _response.Status = true;
                        _response.Message = "Institutions list found.";
                        dataItem.JsonData = dataItem.JsonData = JsonSerializer.Deserialize<InstitutionsListResponse>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "Institution list not found!";
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
        /// GetInstituteCredential
        /// </summary>
        /// <param name="InstituteCode"></param>
        /// <param name="baseUrl"></param>
        /// <param name="basicAuth"></param>
        /// <returns>InstituteCredential</returns>
        public Task<ResponseMessage> GetInstituteCredential(string InstituteCode, string baseUrl,string basicAuth)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new();
            try
            {
                var options = new RestClientOptions(baseUrl + @"/institutions/" + @InstituteCode + @"/credentials")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);

                var request = header.Addheader("Get", basicAuth); /// Calling header helper class

                RestResponse res = client.Execute(request);

                if (res.IsSuccessStatusCode)
                {
                    if (res.Content != null)
                    {
                        _response.Status = true;
                        _response.Message = "Institutions credential found.";
                        dataItem.JsonData = dataItem.JsonData = JsonSerializer.Deserialize<dynamic>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "No credential found for the institution!";
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
