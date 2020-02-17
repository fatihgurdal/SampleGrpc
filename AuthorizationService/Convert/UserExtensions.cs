using AuthorizationService1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Convert
{
    public static class UserExtensions
    {
        #region Dto
        public static Library.Dto.Request.LoginRequest Dto(this LoginRequest message)
        {
            if (message == null) return null;
            return new Library.Dto.Request.LoginRequest()
            {
                Password = message.Password,
                UserName = message.Username
            };
        }

        public static Library.Dto.Request.UserInfoRequest Dto(this UserInfoRequest message)
        {
            if (message == null) return null;
            return new Library.Dto.Request.UserInfoRequest()
            {
                UserName = message.UserName
            };
        }

        #endregion

        #region Message

        public static LoginReply Message(this Library.Dto.Reply.LoginReply dto)
        {
            if (dto == null) return new LoginReply();
            return new LoginReply()
            {
                Message = dto.Message,
                Verification = dto.Verification
            };
        }

        public static UserInfoReply Message(this Library.Dto.Reply.UserInfoReply dto)
        {
            if (dto == null) return new UserInfoReply();
            return new UserInfoReply()
            {
                UserName = dto.UserName,
                Title = dto.Title,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                EMail = dto.EMail,
                PhoneNumber = dto.PhoneNumber
            };
        }
        #endregion
    }
}
