using AuthorizationService.Library.Business.Interface;
using AuthorizationService.Library.Dto.Reply;
using AuthorizationService.Library.Dto.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationService.Library.Business.Concrete
{
    public class UserManager : IUser
    {
        public LoginReply Login(LoginRequest request)
        {
            var verification = (request.UserName == "fgurdal" && request.Password == "1461");
            return new LoginReply
            {
                Verification = verification,
                Message = verification ? "Login Succes" : "User Name or Password not correct",
                Token = verification ? Guid.NewGuid().ToString() : string.Empty
            };
        }
    }
}
