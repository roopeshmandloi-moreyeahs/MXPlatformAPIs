using MXPlatformAPI.Requests;
using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Interfaces
{
    public interface IInstitutionRepository
    {
        /// <summary>
        /// List Institution Interface
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Task<ResponseMessage> ListInstitutions(string BaseUrl);
        public Task<ResponseMessage> GetInstituteCredential(string InstituteCode, string BaseUrl);

    }
}
