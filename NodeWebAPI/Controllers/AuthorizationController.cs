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
            ////var hello = new HelloRequest() { Name = "fatih gürdal" };

            //var channel = GrpcChannel.ForAddress("http://localhost:5012");
            //var client = new Greeter.GreeterClient(channel);

            //var cevap = client.SayHello(new HelloRequest() { Name = "fatih1" });

            ////var response = new LoginResponseModel()
            ////{
            ////    Success = false,
            ////    Message = "Hazır değil"
            ////};
            return new JsonResult("test");
        }
    }
}