using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MXPlatformAPI.Responses
{
    public class HelperDTO
    {
       // [JsonPropertyName("account")]
        public class Account
        {

            [JsonPropertyName("guid")]
            public string? Guid { get; set; }
            
            [JsonPropertyName("id")]
            public string? Id { get; set; }

            [JsonPropertyName("member_guid")]
            public string? MemberGuid { get; set; }

            [JsonPropertyName("member_id")]
            public string? MemberId { get; set; }

            [JsonPropertyName("user_guid")]
            public string? UserGuid { get; set; }

            [JsonPropertyName("user_id")]
            public string? UserId { get; set; }

            [JsonPropertyName("account_number")]
            public string? AccountNumber { get; set; }

            [JsonPropertyName("available_balance")]
            public double? AvailableBalance { get; set; }

            [JsonPropertyName("balance")]
            public double? Balance { get; set; }

            [JsonPropertyName("cash_balance")]
            public double? CashBalance { get; set; }

            [JsonPropertyName("cash_surrender_value")]
            public double? CashSurrenderValue { get; set; }

            [JsonPropertyName("credit_limit")]
            public double? CreditLimit { get; set; }

            [JsonPropertyName("currency_code")]
            public string? CurrencyCode { get; set; }

            [JsonPropertyName("day_payment_is_due")]
            public double? DayPaymentIsDue { get; set; }

            [JsonPropertyName("interest_rate")]
            public double? InterestRate { get; set; }

            [JsonPropertyName("institution_code")]
            public string? InstitutionCode { get; set; }

            [JsonPropertyName("insured_name")]
            public string? InsuredName { get; set; }

            [JsonPropertyName("is_closed")]
            public bool? IsClosed { get; set; }

            [JsonPropertyName("is_hidden")]
            public bool? IsHidden { get; set; }

            [JsonPropertyName("is_manual")]
            public bool? IsManual { get; set; }

            [JsonPropertyName("last_payment")]
            public double? LastPayment { get; set; }

            [JsonPropertyName("loan_amount")]
            public double? LoanAmount { get; set; }

            [JsonPropertyName("margin_balance")]
            public double? MarginBalance { get; set; }

            [JsonPropertyName("member_is_managed_by_user")]
            public bool? MemberIsManagedByUser { get; set; }

            [JsonPropertyName("minimum_balance")]
            public double? MinimumBalance { get; set; }

            [JsonPropertyName("minimum_payment")]
            public double? MinimumPayment { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("nickname")]
            public string? Nickname { get; set; }

            [JsonPropertyName("original_balance")]
            public double? OriginalBalance { get; set; }

            [JsonPropertyName("pay_out_amount")]
            public double? PayOutAmount { get; set; }

            [JsonPropertyName("payoff_balance")]
            public double? PayoffBalance { get; set; }

            [JsonPropertyName("premium_amount")]
            public double? PremiumAmount { get; set; }

            [JsonPropertyName("today_ugl_amount")]
            public double? TodayUglAmount { get; set; }

            [JsonPropertyName("today_ugl_percentage")]
            public double? TodayUglPercentage { get; set; }

            [JsonPropertyName("total_account_value")]
            public double? TotalAccountValue { get; set; }

            [JsonPropertyName("subtype")]
            public string? Subtype { get; set; }

            [JsonPropertyName("type")]
            public string? Type { get; set; }

        }

        public class Pagination
        {
            [JsonPropertyName("current_page")]
            public int? CurrentPage { get; set; }

            [JsonPropertyName("per_page")]
            public int? PerPage { get; set; }

            [JsonPropertyName("total_entries")]
            public int? TotalEntries { get; set; }

            [JsonPropertyName("total_pages")]
            public int? TotalPages { get; set; }
        }

        public class RootResponse
        {
            [JsonPropertyName("accounts")]
            public List<Account> Accounts { get; set; }

            [JsonPropertyName("pagination")]
            public Pagination Pagination { get; set; }
        }

        public class Transaction
        {
            [JsonPropertyName("date")]
            public DateTime Date { get; set; }

            [JsonPropertyName("amount")]
            public double Amount { get; set; }
            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("guid")]
            public string Guid { get; set; }
        }

        public class RootObject
        {
            [JsonPropertyName("transactions")]
            public List<Transaction> Transactions { get; set; }


            [JsonPropertyName("pagination")]
            public Pagination Pagination { get; set; }
        }
    }
}
