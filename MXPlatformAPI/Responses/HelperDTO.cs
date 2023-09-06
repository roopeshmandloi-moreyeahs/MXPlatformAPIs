using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MXPlatformAPI.Responses
{
    public class HelperDTO
    {
        public class Account
        {
            [JsonProperty("guid")]
            [JsonPropertyName("guid")]
            public string? Guid { get; set; }

            [JsonProperty("id")]
            [JsonPropertyName("id")]
            public string? Id { get; set; }

            [JsonProperty("member_guid")]
            [JsonPropertyName("member_guid")]
            public string? MemberGuid { get; set; }

            [JsonProperty("member_id")]
            [JsonPropertyName("member_id")]
            public string? MemberId { get; set; }

            [JsonProperty("user_guid")]
            [JsonPropertyName("user_guid")]
            public string? UserGuid { get; set; }

            [JsonProperty("user_id")]
            [JsonPropertyName("user_id")]
            public string? UserId { get; set; }

            [JsonProperty("account_number")]
            [JsonPropertyName("account_number")]
            public string? AccountNumber { get; set; }

            [JsonProperty("available_balance")]
            [JsonPropertyName("available_balance")]
            public double? AvailableBalance { get; set; }

            [JsonProperty("balance")]
            [JsonPropertyName("balance")]
            public double? Balance { get; set; }

            [JsonProperty("cash_balance")]
            [JsonPropertyName("cash_balance")]
            public double? CashBalance { get; set; }

            [JsonProperty("cash_surrender_value")]
            [JsonPropertyName("cash_surrender_value")]
            public double? CashSurrenderValue { get; set; }

            [JsonProperty("credit_limit")]
            [JsonPropertyName("credit_limit")]
            public double? CreditLimit { get; set; }

            [JsonProperty("currency_code")]
            [JsonPropertyName("currency_code")]
            public string? CurrencyCode { get; set; }

            [JsonProperty("day_payment_is_due")]
            [JsonPropertyName("day_payment_is_due")]
            public double? DayPaymentIsDue { get; set; }


            [JsonProperty("interest_rate")]
            [JsonPropertyName("interest_rate")]
            public double? InterestRate { get; set; }

            [JsonProperty("institution_code")]
            [JsonPropertyName("institution_code")]
            public string? InstitutionCode { get; set; }

            [JsonProperty("insured_name")]
            [JsonPropertyName("insured_name")]
            public string? InsuredName { get; set; }

            [JsonProperty("is_closed")]
            [JsonPropertyName("is_closed")]
            public bool? IsClosed { get; set; }

            [JsonProperty("is_hidden")]
            [JsonPropertyName("is_hidden")]
            public bool? IsHidden { get; set; }

            [JsonProperty("is_manual")]
            [JsonPropertyName("is_manual")]
            public bool? IsManual { get; set; }

            [JsonProperty("last_payment")]
            [JsonPropertyName("last_payment")]
            public double? LastPayment { get; set; }

            [JsonProperty("loan_amount")]
            [JsonPropertyName("loan_amount")]
            public double? LoanAmount { get; set; }

            [JsonProperty("margin_balance")]
            [JsonPropertyName("margin_balance")]
            public double? MarginBalance { get; set; }

            [JsonProperty("member_is_managed_by_user")]
            [JsonPropertyName("member_is_managed_by_user")]
            public bool? MemberIsManagedByUser { get; set; }

            [JsonProperty("minimum_balance")]
            [JsonPropertyName("minimum_balance")]
            public double? MinimumBalance { get; set; }

            [JsonProperty("minimum_payment")]
            [JsonPropertyName("minimum_payment")]
            public double? MinimumPayment { get; set; }

            [JsonProperty("name")]
            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonProperty("nickname")]
            [JsonPropertyName("nickname")]
            public string? Nickname { get; set; }

            [JsonProperty("original_balance")]
            [JsonPropertyName("original_balance")]
            public double? OriginalBalance { get; set; }

            [JsonProperty("pay_out_amount")]
            [JsonPropertyName("pay_out_amount")]
            public double? PayOutAmount { get; set; }

            [JsonProperty("payoff_balance")]
            [JsonPropertyName("payoff_balance")]
            public double? PayoffBalance { get; set; }

            [JsonProperty("premium_amount")]
            [JsonPropertyName("premium_amount")]
            public double? PremiumAmount { get; set; }

            [JsonProperty("today_ugl_amount")]
            [JsonPropertyName("today_ugl_amount")]
            public double? TodayUglAmount { get; set; }

            [JsonProperty("today_ugl_percentage")]
            [JsonPropertyName("today_ugl_percentage")]
            public double? TodayUglPercentage { get; set; }

            [JsonProperty("total_account_value")]
            [JsonPropertyName("total_account_value")]
            public double? TotalAccountValue { get; set; }

            [JsonProperty("subtype")]
            [JsonPropertyName("subtype")]
            public string? Subtype { get; set; }

            [JsonProperty("type")]
            [JsonPropertyName("type")]
            public string? Type { get; set; }

        }

        public class Pagination
        {
            [JsonProperty("current_page")]
            [JsonPropertyName("current_page")]
            public int? CurrentPage { get; set; }

            [JsonProperty("per_page")]
            [JsonPropertyName("per_page")]
            public int? PerPage { get; set; }

            [JsonProperty("total_entries")]
            [JsonPropertyName("total_entries")]
            public int? TotalEntries { get; set; }

            [JsonProperty("total_pages")]
            [JsonPropertyName("total_pages")]
            public int? TotalPages { get; set; }
        }

        public class RootResponse
        {
            [JsonProperty("accounts")]
            [JsonPropertyName("accounts")]
            public List<Account> Accounts { get; set; }

            [JsonProperty("pagination")]
            [JsonPropertyName("pagination")]
            public Pagination Pagination { get; set; }
        }

        public class Transaction
        {
            [JsonProperty("date")]
            [JsonPropertyName("date")]
            public DateTime Date { get; set; }

            [JsonProperty("amount")]
            [JsonPropertyName("amount")]
            public double Amount { get; set; }
            [JsonProperty("description")]
            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonProperty("guid")]
            [JsonPropertyName("guid")]
            public string Guid { get; set; }
        }

        public class RootObject
        {
            [JsonProperty("transactions")]
            [JsonPropertyName("transactions")]
            public List<Transaction> Transactions { get; set; }


            [JsonProperty("pagination")]
            [JsonPropertyName("pagination")]
            public Pagination Pagination { get; set; }
        }
    }
}
