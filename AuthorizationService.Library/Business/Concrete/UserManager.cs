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
        public UserInfoReply GetUser(UserInfoRequest request)
        {
            if (request.UserName == "fgurdal")
            {
                return new UserInfoReply()
                {
                    UserName = "fgurdal",
                    PhoneNumber = "+90 500 000 00 00",
                    EMail = "f.gurdal@hotmail.com.tr",
                    FirstName = "Fatih",
                    LastName = "GÜRDAL",
                    Title = "Software Developer"
                };
            }
            else return null;
        }

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
