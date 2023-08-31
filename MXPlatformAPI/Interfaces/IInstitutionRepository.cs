using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Interfaces
{
    public interface IInstitutionRepository
    {
        /// <summary>
        ///  List Institution Interface
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="basicAuth"></param>
        /// <returns></returns>
        public Task<ResponseMessage> ListInstitutions(string baseUrl, string basicAuth);

        /// <summary>
        /// GetInstituteCredential
        /// </summary>
        /// <param name="InstituteCode"></param>
        /// <param name="baseUrl"></param>
        /// <param name="basicAuth"></param>
        /// <returns>List of Credential for the Institute </returns>
        public Task<ResponseMessage> GetInstituteCredential(string InstituteCode, string baseUrl, string basicAuth);

    }
}
