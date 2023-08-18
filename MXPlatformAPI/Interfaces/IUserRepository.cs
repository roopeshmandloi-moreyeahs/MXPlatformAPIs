using MXPlatformAPI.Responses;
using MXPlatformAPI.Requests;

namespace MXPlatformAPI.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Create User InterFace
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Task<ResponseMessage> CreateUser(RequestModels.Root root, string BaseUrl);
        
        /// <summary>
        /// List User Interface
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Task<ResponseMessage> ListUser(string BaseUrl);
    }
}
