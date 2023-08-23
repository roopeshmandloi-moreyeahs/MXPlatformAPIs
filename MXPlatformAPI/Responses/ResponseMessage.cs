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
        public user? user { get; set; }
    }

    public class ListUserResponse
    {
        public List<user>? users { get; set; }
    }


    public class user
    {
        public string? guid { get; set; }
        public string? id { get; set; }
        public string? email { get; set; }
        public bool is_disabled { get; set; }
        public string? metadata { get; set; }
    }

    public class InstitutionsListResponse
    {
        public List<Object>? institutions { get; set; }
    }
}
