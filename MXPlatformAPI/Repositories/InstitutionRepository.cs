using MXPlatformAPI.Helper;
using MXPlatformAPI.Interfaces;
using MXPlatformAPI.Responses;
using RestSharp;
using System.Text.Json;
namespace MXPlatformAPI.Repositories
{
    public class InstitutionRepository : IInstitutionRepository
    {
        readonly IConfiguration _iConfig;

        readonly string baseUrl;
      
        public InstitutionRepository(IConfiguration iConfig)
        {
            baseUrl = iConfig.GetSection("ApiSettings").GetSection("baseUrl").Value;
            _iConfig = iConfig;
        }

   
        /// <summary>
        /// ListInstitutions
        /// </summary>
        /// <returns>Institution list</returns>
        public Task<ResponseMessage> ListInstitutions()
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new(_iConfig);
            try
            {
                var options = new RestClientOptions(baseUrl + @"/institutions")
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

                        dataItem = JsonSerializer.Deserialize<dynamic>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

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
        /// <param name="instituteCode"></param>
        /// <returns>InstituteCredential</returns>
        public Task<ResponseMessage> GetInstituteCredential(string instituteCode)
        {
            ResponseMessage _response = new();
            Data dataItem = new();
            HeaderHelperClass header = new(_iConfig);
            try
            {
                var options = new RestClientOptions(baseUrl + @"/institutions/" + @instituteCode + @"/credentials")
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
                        dataItem.JsonData = JsonSerializer.Deserialize<dynamic>(res.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

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
