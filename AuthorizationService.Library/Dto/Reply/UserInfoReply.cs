using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationService.Library.Dto.Reply
{
    public class UserInfoReply
    {
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
    }
}
