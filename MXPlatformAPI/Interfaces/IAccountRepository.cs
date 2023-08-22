using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Interfaces
{
    public interface IAccountRepository
    {
        /// <summary>
        /// List Accounts By User Guid Interface
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Task<ResponseMessage> ListAccountData(string UserGuid, string BaseUrl);

    }
}
