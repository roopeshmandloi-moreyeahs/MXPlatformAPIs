using MXPlatformAPI.Requests;
using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Interfaces
{
    public interface IMemberRepository
    {
        /// <summary>
        /// Create Member InterFace
        /// </summary>
        /// <param name="CreateMemberRoot"></param>
        /// <param name="UserGuid"></param>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public Task<ResponseMessage> CreateMember(RequestModels.CreateMemberRoot root, string UserGuid, string BaseUrl);

        /// <summary>
        /// Check Member Status
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Task<ResponseMessage> CheckMemberStatus(string UserGuid, string MemberGuid, string BaseUrl);
        public Task<ResponseMessage> ListMembers(string UserGuid, string BaseUrl);

    }
}
