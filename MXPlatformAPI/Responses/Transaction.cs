using System.Text.Json.Serialization;

namespace MXPlatformAPI.Responses
{
    public class Transaction
    {
        [property: JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [property: JsonPropertyName("amount")]
        public double Amount { get; set; }
        [property: JsonPropertyName("description")]
        public string Description { get; set; }
        [property: JsonPropertyName("guid")]
        public string Guid { get; set; }
    }

    public class RootObject
    {
        [property: JsonPropertyName("transactions")]
        public List<Transaction> Transactions { get; set; }
    }
}
