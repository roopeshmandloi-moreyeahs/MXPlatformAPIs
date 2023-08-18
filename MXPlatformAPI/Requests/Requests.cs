using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Xml.Linq;

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

    }
}
