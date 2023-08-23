using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Interfaces
{
    public interface ITransactionRepository
    {
        /// <summary>
        /// List Transactions By User Guid & Account Guid Interface
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Task<ResponseMessage> ListTransactionData(string UserGuid, string AccountGuid, string BaseUrl);
        
        /// <summary>
        /// List Transactions By User Guid & Member Guid Interface
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Task<ResponseMessage> ListTransactionDataByMember(string UserGuid, string MemberGuid, string BaseUrl);

        /// Get Transactions detail By Transaction Guid Interface
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Task<ResponseMessage> ReadTransactionDataByTransactionGuid(string UserGuid, string TransactionGuid, string BaseUrl);

        /// List Transactions By User Guid Interface
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Task<ResponseMessage> ListTransactionDataByUserGuid(string UserGuid, string BaseUrl);
    }
}
