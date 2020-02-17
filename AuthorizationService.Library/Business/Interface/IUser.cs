using AuthorizationService.Library.Dto.Reply;
using AuthorizationService.Library.Dto.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationService.Library.Business.Interface
{
    public interface IUser
    {
        LoginReply Login(LoginRequest request);
        UserInfoReply GetUser(UserInfoRequest request);
    }
}
