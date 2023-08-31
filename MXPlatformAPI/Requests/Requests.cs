using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MXPlatformAPI.Requests
{
    public class RequestModels
    {
        public class Root
        {
            [property: JsonPropertyName("user")]
            public User? User { get; set; } = default;
        }

        public class User
        {

            public string? Email { get; set; }
            [property: JsonPropertyName("id")]
            public string? Id { get; set; }
            [DefaultValue(false)]

            [property: JsonPropertyName("is_disabled")]
            public bool IsDisabled { get; set; }
            [property: JsonPropertyName("metadata")]
            public string? MetaData { get; set; }
        }

        public class Credential
        {
            [property: JsonPropertyName("guid")]
            public string? Guid { get; set; }
            [property: JsonPropertyName("value")]
            public string? Value { get; set; }
        }

        public class Member
        {
            [property: JsonPropertyName("credentials")]
            public List<Credential>? Credentials { get; set; }
            [property: JsonPropertyName("id")]
            public string? Id { get; set; }
            [property: JsonPropertyName("institution_code")]
            public string? InstitutionCode { get; set; }
            [DefaultValue(true)]
            [property: JsonPropertyName("is_oauth")]
            public bool IsOauth { get; set; }
            [property: JsonPropertyName("metadata")]
            public string? MetaData { get; set; }
        }

        public class CreateMemberRoot
        {
            [property: JsonPropertyName("member")]
            public Member? Member { get; set; }
            [DefaultValue("BROWSER")]
            [property: JsonPropertyName("referral_source")]
            public string? ReferralSource { get; set; }
        }


    }
}
