using System.Text.Json.Serialization;

namespace MXPlatformAPI.Responses
{
    public class ResponseNew
    {
        
        public class Account
        {
       
            [property: JsonPropertyName("account_number")]
            public string? AccountNumber;

            [property: JsonPropertyName("account_type")]
            public string? AccountType;

            [property: JsonPropertyName("currency_code")]
            public string? CurrencyCode;

            [property: JsonPropertyName("data_source_id")]
            public string? DataSourceId;

            [property: JsonPropertyName("external_account_id")]
            public string? ExternalAccountId;

            [property: JsonPropertyName("current_balance")]
            public string? CurrentBalance;

            [property: JsonPropertyName("available_balance")]
            public string? AvailableBalance;

            [property: JsonPropertyName("transactions")]
            public List<Transaction> Transactions;
        }

        public class Address
        {
            [property: JsonPropertyName("street")]
            public string? Street;

            [property: JsonPropertyName("street2")]
            public object Street2;

            [property: JsonPropertyName("city")]
            public string? City;

            [property: JsonPropertyName("region")]
            public string? Region;

            [property: JsonPropertyName("postal_code")]
            public string? PostalCode;

            [property: JsonPropertyName("country")]
            public string? Country;
        }

        public class ConsumerInformation
        {
            [property: JsonPropertyName("first_name")]
            public object FirstName;

            [property: JsonPropertyName("last_name")]
            public object LastName;

            [property: JsonPropertyName("full_name")]
            public string? FullName;

            [property: JsonPropertyName("identifiers")]
            public List<Identifier> Identifiers;

            [property: JsonPropertyName("date_of_birth")]
            public string? DateOfBirth;

            [property: JsonPropertyName("email")]
            public List<string?> Email;

            [property: JsonPropertyName("phone_number")]
            public object PhoneNumber;

            [property: JsonPropertyName("address")]
            public Address Address;

            
        }

        public class Identifier
        {
            [property: JsonPropertyName("source")]
            public string? Source;

            [property: JsonPropertyName("id")]
            public string? Id;
        }

        public class Institution
        {
            [property: JsonPropertyName("external_institution_id")]
            public string? ExternalInstitutionId;

            [property: JsonPropertyName("name")]
            public string? Name;

            [property: JsonPropertyName("accounts")]
            public List<Account> Accounts;
        }

        public class ResponseRoot
        {
            [property: JsonPropertyName("consumer_information")]
            public ConsumerInformation ConsumerInformation;

            [property: JsonPropertyName("institutions")]
            public List<Institution> Institutions;
        }

        public class Transaction
        {
            [property: JsonPropertyName("external_transaction_id")]
            public string? ExternalTransactionId;

            [property: JsonPropertyName("date")]
            public DateTime? Date;

            [property: JsonPropertyName("description")]
            public string? Description;

            [property: JsonPropertyName("action")]
            public string? Action;

            [property: JsonPropertyName("amount")]
            public double? Amount;
        }


    }
}
