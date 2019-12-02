using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AuthorizationService;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NodeWebAPI.Model.Request;
using NodeWebAPI.Model.Response;


namespace NodeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        public async Task<IActionResult> Login(LoginRequestModel request)
        {
            //var hello = new HelloRequest() { Name = "fatih gürdal" };

            var channel = GrpcChannel.ForAddress("http://localhost:5012");
            var client = new Greeter.GreeterClient(channel);


            var response = new LoginResponseModel()
            {
                Success = false,
                Message = "Hazır değil"
            };
            return new JsonResult(response);
        }
    }
}