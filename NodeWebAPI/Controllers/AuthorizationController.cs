using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AuthorizationService;
using AuthorizationService1;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NodeWebAPI.Model.Request;
using NodeWebAPI.Model.Response;


namespace NodeWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody]LoginRequestModel request)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:4001");
            var client = new Greeter.GreeterClient(channel);

            var input = new LoginRequest() { Password = request.Password, Username = request.UserName };
            var result = client.Login(input);

            return new JsonResult($"{result.Message} - {result.Verification}");
        }
    }
}