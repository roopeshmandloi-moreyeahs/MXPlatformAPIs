using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Interfaces
{
    public interface ITransactionRepository
    {
        /// <summary>
        /// List Transactions By User Guid & Account Guid Interface
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="AccountGuid"></param>
        /// <returns></returns>
        public Task<ResponseMessage> ListTransactionData(string UserGuid, string AccountGuid);

        /// <summary>
        /// List Transactions By User Guid & Member Guid Interface
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="MemberGuid"></param>
        /// <returns>Transactions List</returns>
        public Task<ResponseMessage> ListTransactionDataByMember(string UserGuid, string MemberGuid);

        /// <summary>
        /// Get Transactions detail By Transaction Guid Interface
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="TransactionGuid"></param>
        /// <returns>Transaction data</returns>
        public Task<ResponseMessage> ReadTransactionDataByTransactionGuid(string UserGuid, string TransactionGuid);

        /// <summary>
        /// Get Aggregated Transaction Data By User Guid Interface
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <returns></returns>
        public Task<ResponseMessage> GetAggregatedDataByUserGuid(string UserGuid);
        /// <summary>
        /// List Transactions By User Guid Interface
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <returns></returns>
        public Task<ResponseMessage> ListTransactionDataByUserGuid(string UserGuid);
    }
}
