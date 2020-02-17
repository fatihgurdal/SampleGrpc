using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AuthorizationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string jsonFileName = Path.Combine(assemblyFolder, "Properties\\launchSettings.json");
            if (File.Exists(jsonFileName))
            {
                using (var file = File.OpenText(jsonFileName))
                {
                    Common.EnvironmentVariableHelper.SetEnvironmentVariable(file); //Launch setting'de olan enviroment variable'ları atar
                }
            }

            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hoster = Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
            return hoster;
        }

    }
}
