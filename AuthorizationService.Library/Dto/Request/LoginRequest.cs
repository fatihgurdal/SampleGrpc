using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationService.Library.Dto.Request
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
