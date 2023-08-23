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
        /// List of Institutes
        /// </summary>
        /// <returns>List</returns>
        public Task<ResponseMessage> ListInstitutions(string BaseUrl)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new();
            try
            {
                var options = new RestClientOptions(BaseUrl + @"/institutions")
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
        /// Get credential of an Institute
        /// </summary>
        /// <returns>List</returns>
        public Task<ResponseMessage> GetInstituteCredential(string InstituteCode, string BaseUrl)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new();
            try
            {
                var options = new RestClientOptions(BaseUrl + @"/institutions/" + @InstituteCode + @"/credentials")
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
