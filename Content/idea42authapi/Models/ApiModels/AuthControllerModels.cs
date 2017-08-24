using System;

namespace WebApplicationBasic.Models.ApiModels
{
    public class NewUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class UpdateUserRequest : NewUserRequest
    {

    }

    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
