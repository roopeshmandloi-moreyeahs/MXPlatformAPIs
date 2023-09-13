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
        /// <returns>member_guid</returns>
        public Task<ResponseMessage> CreateMember(RequestModels.CreateMemberRoot root, string UserGuid);

        /// <summary>
        /// Check Member Status
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="MemberGuid"></param>
        /// <returns>Status</returns>
        public Task<ResponseMessage> CheckMemberStatus(string UserGuid, string MemberGuid);

        /// <summary>
        /// List Members
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <returns>Member list</returns>
        public Task<ResponseMessage> ListMembers(string UserGuid);

    }
}
