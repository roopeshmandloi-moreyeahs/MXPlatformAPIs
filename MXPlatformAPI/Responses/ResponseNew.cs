using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MXPlatformAPI.Responses
{
    public class ResponseNew
    {

        public class MyResponse
        {
            public string? Message { get; set; }
            public bool Status { get; set; }
            public ResponseRoot response { get; set; }
        }

       // [JsonProperty(PropertyName = "account")]
        public class Account
        {
            [JsonProperty(PropertyName = "account_number")]

            public string? AccountNumber;

            [JsonProperty(PropertyName = "account_type")]
            public string? AccountType;

            [JsonProperty(PropertyName = "currency_code")]
            public string? CurrencyCode;

            [JsonProperty(PropertyName = "data_source_id")]
            public string? DataSourceId;

            [JsonProperty(PropertyName = "external_account_id")]
            public string? ExternalAccountId;

            [JsonProperty(PropertyName = "current_balance")]
            public string? CurrentBalance;

            [JsonProperty(PropertyName = "available_balance")]
            public string? AvailableBalance;

            [JsonProperty(PropertyName = "transactions")]
            public List<Transaction> Transactions;
        }

        public class Address
        {
            [JsonProperty(PropertyName = "street")]
            public string? Street;

            [JsonProperty(PropertyName = "street2")]
            public object Street2;

            [JsonProperty(PropertyName = "city")]
            public string? City;

            [JsonProperty(PropertyName = "region")]
            public string? Region;

            [JsonProperty(PropertyName = "postal_code")]
            public string? PostalCode;

            [JsonProperty(PropertyName = "country")]
            public string? Country;
        }

        public class ConsumerInformation
        {
            [JsonProperty(PropertyName = "first_name")]
            public object FirstName;

            [JsonProperty(PropertyName = "last_name")]
            public object LastName;

            [JsonProperty(PropertyName = "full_name")]
            public string? FullName;

            [JsonProperty(PropertyName = "identifiers")]
            public List<Identifier> Identifiers;

            [JsonProperty(PropertyName = "date_of_birth")]
            public string? DateOfBirth;

            [JsonProperty(PropertyName = "email")]
            public List<string?> Email;

            [JsonProperty(PropertyName = "phone_number")]
            public object PhoneNumber;

            [JsonProperty(PropertyName = "address")]
            public Address Address;

            
        }


        public class Identifier
        {
            [JsonProperty(PropertyName = "source")]
            public string? Source;

            [JsonProperty(PropertyName = "id")]
            public string? Id;
        }

        public class Institution
        {
            [JsonProperty(PropertyName = "external_institution_id")]
            public string? ExternalInstitutionId;

            [JsonProperty(PropertyName = "name")]
            public string? Name;

            [JsonProperty(PropertyName = "accounts")]
            public List<Account> Accounts;
        }

        public class ResponseRoot
        {
            [JsonProperty(PropertyName = "consumer_information")]
            public ConsumerInformation ConsumerInformation;

            [JsonProperty(PropertyName = "institutions")]
            public List<Institution> Institutions;
        }

        public class Transaction
        {
            [JsonProperty(PropertyName = "external_transaction_id")]
            public string? ExternalTransactionId;

            [JsonProperty(PropertyName = "date")]
            public DateTime? Date;

            [JsonProperty(PropertyName = "description")]
            public string? Description;

            [JsonProperty(PropertyName = "action")]
            public string? Action;

            [JsonProperty(PropertyName = "amount")]
            public double? Amount;
        }


    }
}
