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
        /// <returns>User with user_guid</returns>
        public Task<ResponseMessage> CreateUser(RequestModels.Root root);

        /// <summary>
        /// ListUser
        /// </summary>
        /// <returns>User List </returns>
        public Task<ResponseMessage> ListUser();
    }
}
