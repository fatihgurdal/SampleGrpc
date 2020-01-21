using System;
using System.Threading.Tasks;
using AuthorizationService1;
using Grpc.Net.Client;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
          


            var channel = GrpcChannel.ForAddress("https://localhost:4001");
            var client = new Greeter.GreeterClient(channel);

            var userName = "";
            var password = "";

            while (userName != "exit")
            {
                Console.Write("User Name: ");
                userName = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();

                var input = new LoginRequest() { Password = password, Username = userName };
                var result = await client.LoginAsync(input);

                Console.WriteLine(result.Verification);
                Console.WriteLine(result.Message);
            }
       

            Console.ReadLine();
        }
    }
}
