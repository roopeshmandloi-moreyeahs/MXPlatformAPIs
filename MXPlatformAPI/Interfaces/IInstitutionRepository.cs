using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Interfaces
{
    public interface IInstitutionRepository
    {
        /// <summary>
        ///  List Institution Interface
        /// </summary>
        /// <returns></returns>
        public Task<ResponseMessage> ListInstitutions();

        /// <summary>
        /// GetInstituteCredential
        /// </summary>
        /// <param name="InstituteCode"></param>
        /// <returns>List of Credential for the Institute </returns>
        public Task<ResponseMessage> GetInstituteCredential(string InstituteCode);

    }
}
