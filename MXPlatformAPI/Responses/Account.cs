namespace MXPlatformAPI.Responses
{
 
        public class Account
        {
            public string guid { get; set; }
            public string id { get; set; }
            public string member_guid { get; set; }
            public string member_id { get; set; }
            public string user_guid { get; set; }
            public string user_id { get; set; }
            public string account_number { get; set; }
            public object annuity_policy_to_date { get; set; }
            public object annuity_provider { get; set; }
            public object annuity_term_year { get; set; }
            public object apr { get; set; }
            public object apy { get; set; }
            public double available_balance { get; set; }
            public double? available_credit { get; set; }
            public double balance { get; set; }
            public object cash_balance { get; set; }
            public object cash_surrender_value { get; set; }
            public object credit_limit { get; set; }
            public string currency_code { get; set; }
            public int day_payment_is_due { get; set; }
            public object death_benefit { get; set; }
            public object holdings_value { get; set; }
            public double? interest_rate { get; set; }
            public string institution_code { get; set; }
            public object insured_name { get; set; }
            public bool is_closed { get; set; }
            public bool is_hidden { get; set; }
            public bool is_manual { get; set; }
            public object last_payment { get; set; }
            public object loan_amount { get; set; }
            public object margin_balance { get; set; }
            public object matures_on { get; set; }
            public bool member_is_managed_by_user { get; set; }
            public object metadata { get; set; }
            public object minimum_balance { get; set; }
            public object minimum_payment { get; set; }
            public string name { get; set; }
            public object nickname { get; set; }
            public object original_balance { get; set; }
            public object pay_out_amount { get; set; }
            public object payoff_balance { get; set; }
            public object premium_amount { get; set; }
            public object property_type { get; set; }
            public string routing_number { get; set; }
            public object started_on { get; set; }
            public object today_ugl_amount { get; set; }
            public object today_ugl_percentage { get; set; }
            public object total_account_value { get; set; }
            public string subtype { get; set; }
            public string type { get; set; }
            public object account_ownership { get; set; }
            public DateTime created_at { get; set; }
            public DateTime imported_at { get; set; }
            public object last_payment_at { get; set; }
            public DateTime payment_due_at { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class Pagination
        {
            public int current_page { get; set; }
            public int per_page { get; set; }
            public int total_entries { get; set; }
            public int total_pages { get; set; }
        }

        public class Root
        {
            public List<Account> accounts { get; set; }
            public Pagination pagination { get; set; }
        }
}

