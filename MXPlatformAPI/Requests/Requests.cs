using System.ComponentModel;

namespace MXPlatformAPI.Requests
{
    public class RequestModels
    {
        public class Root
        {
            public User? user { get; set; }
        }

        public class User
        {
            public string? email { get; set; }
            public string? id { get; set; }
            [DefaultValue(false)]
            public bool is_disabled { get; set; }
            public string? metadata { get; set; }
        }

        public class Credential
        {
            public string guid { get; set; }
            public string value { get; set; }
        }

        public class Member
        {
            public List<Credential>? credentials { get; set; }
            public string? id { get; set; }
            public string? institution_code { get; set; }
            [DefaultValue(true)]
            public bool is_oauth { get; set; }
            public string? metadata { get; set; }
        }

        public class CreateMemberRoot
        {
            public Member? member { get; set; }
            [DefaultValue("Browser")]
            public string? referral_source { get; set; }
        }


    }
}
