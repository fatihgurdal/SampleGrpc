using System;
using Grpc.Net.Client;

namespace GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var channel = GrpcChannel.ForAddress("");
           var client = new AuthorizationService.cli
        }
    }
}
