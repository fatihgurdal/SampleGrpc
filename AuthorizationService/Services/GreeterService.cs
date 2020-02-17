using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationService.Convert;
using AuthorizationService.Library.Business.Interface;
using AuthorizationService1;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace AuthorizationService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IUser UserManager;
        public GreeterService(ILogger<GreeterService> logger, IUser userManager)
        {
            _logger = logger;
            UserManager = userManager;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<LoginReply> Login(LoginRequest request, ServerCallContext context)
        {
            return Task.FromResult(UserManager.Login(request.Dto()).Message());
        }
    }
}
