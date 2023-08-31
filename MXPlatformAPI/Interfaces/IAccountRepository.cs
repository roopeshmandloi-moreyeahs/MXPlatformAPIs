using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Interfaces
{
    public interface IAccountRepository
    {
        /// <summary>
        /// List Accounts By User Guid Interface
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="baseUrl"></param>
        /// <param name="basicAuth"></param>
        /// <returns>Account data</returns>
        public Task<ResponseMessage> ListAccountData(string UserGuid, string baseUrl,string basicAuth);

    }
}
