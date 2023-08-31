using System.Text.Json.Serialization;

namespace MXPlatformAPI.Responses
{
    public class ResponseMessage
    {
        public string? Message { get; set; }
        public bool Status { get; set; }
        public Data? Data { get; set; }
    }

    public class Data
    {
        public object? JsonData { get; set; }
    }
    public class CreateUserResponse
    {
        [property: JsonPropertyName("user")]
        public User? User { get; set; }
    }

    public class ListUserResponse
    {
        [property: JsonPropertyName("users")]
        public List<User>? Users { get; set; }
    }


    public class User
    {
        [property: JsonPropertyName("guid")]
        public string? Guid { get; set; }
        [property: JsonPropertyName("id")]
        public string? Id { get; set; }
        [property: JsonPropertyName("email")]
        public string? Email { get; set; }
        [property: JsonPropertyName("is_disabled")]
        public bool IsDisabled { get; set; }
        [property: JsonPropertyName("metadata")]
        public string? MetaData { get; set; }
    }

    public class InstitutionsListResponse
    {
        [property: JsonPropertyName("institutions")]
        public List<Object>? Institutions { get; set; }
    }
}
