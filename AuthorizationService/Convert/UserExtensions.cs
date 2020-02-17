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
            return new Library.Dto.Request.LoginRequest()
            {
                Password = message.Password,
                UserName = message.Username
            };

        }

        #endregion

        #region Message

        public static LoginReply Message(this Library.Dto.Reply.LoginReply dto)
        {
            return new LoginReply()
            {
                Message = dto.Message,
                Verification = dto.Verification
            };
        }
        #endregion
    }
}
