using MXPlatformAPI.Requests;
using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// CreateUser
        /// </summary>
        /// <param name="root"></param>
        /// <param name="baseUrl"></param>
        /// <param name="basicAuth"></param>
        /// <returns>User with user_guid</returns>
        public Task<ResponseMessage> CreateUser(RequestModels.Root root, string baseUrl,string basicAuth);

        /// <summary>
        /// ListUser
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="basicAuth"></param>
        /// <returns>User List </returns>
        public Task<ResponseMessage> ListUser(string baseUrl,string basicAuth);
    }
}
