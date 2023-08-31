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
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public Task<ResponseMessage> ListTransactionData(string UserGuid, string AccountGuid, string baseUrl, string basicAuth);

        /// <summary>
        /// List Transactions By User Guid & Member Guid Interface
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="MemberGuid"></param>
        /// <param name="baseUrl"></param>
        /// <returns>Transactions List</returns>
        public Task<ResponseMessage> ListTransactionDataByMember(string UserGuid, string MemberGuid, string baseUrl, string basicAuth);

        /// <summary>
        /// Get Transactions detail By Transaction Guid Interface
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="TransactionGuid"></param>
        /// <param name="baseUrl"></param>
        /// <returns>Transaction data</returns>
        public Task<ResponseMessage> ReadTransactionDataByTransactionGuid(string UserGuid, string TransactionGuid, string baseUrl, string basicAuth);

        /// <summary>
        /// List Transactions By User Guid Interface
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="baseUrl"></param>
        /// <param name="baseAuth"></param>
        /// <returns></returns>
        public Task<ResponseMessage> ListTransactionDataByUserGuid(string UserGuid, string baseUrl, string basicAuth);
    }
}
