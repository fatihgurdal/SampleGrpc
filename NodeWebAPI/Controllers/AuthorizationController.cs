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
using NodeWebAPI.Model.Request;
using NodeWebAPI.Model.Response;
using Microsoft.AspNetCore.Mvc;


namespace NodeWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        [HttpPost]
        public ActionResult Login([FromBody]LoginRequestModel request)
        {
            using (var channel = GrpcChannel.ForAddress(Environment.GetEnvironmentVariable(ApiConst.AuthorizationService)))
            {
                var client = new Greeter.GreeterClient(channel);

                var input = new LoginRequest() { Password = request.Password, Username = request.UserName };
                var result = client.Login(input);

                if (result.Verification)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }
        [HttpGet]
        public ActionResult GetUser([FromQuery]string username)
        {
            using (var channel = GrpcChannel.ForAddress(Environment.GetEnvironmentVariable(ApiConst.AuthorizationService)))
            {
                var client = new Greeter.GreeterClient(channel);

                var input = new UserInfoRequest() { UserName = username };
                var result = client.UserInfo(input);

                if (string.IsNullOrEmpty(result.UserName))
                    return NotFound($"{username} not found user. Try again.");
                else
                    return Ok(result);
            }
        }
    }
}