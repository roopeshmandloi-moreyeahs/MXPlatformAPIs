using MXPlatformAPI.Responses;

namespace MXPlatformAPI.Interfaces
{
    public interface ITransactionRepositoryTest
    {
      
        /// <summary>
        /// Get Aggregated Transaction Data By User Guid Interface
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="baseUrl"></param>
        /// <param name="baseAuth"></param>
        /// <returns></returns>
        public Task<ResponseMessage> GetAggregatedDataByUserGuidTest(string UserGuid, string baseUrl, string basicAuth);
    }
}
