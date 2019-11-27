using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace AuthorizationService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
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
            return Task.FromResult(new LoginReply
            {
                Verification = (request.Username=="fgurdal" && request.Password=="1461"),
                Message = (request.Username == "fgurdal" && request.Password == "1461")?"Login Succes":"User Name or Password not correct"
            });
        }
    }
}
