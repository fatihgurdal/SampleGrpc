using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationService.Library.Dto.Reply
{
    public class LoginReply
    {
        public string Token { get; set; }
        public bool Verification { get; set; }
        public string Message { get; set; }
    }
}
