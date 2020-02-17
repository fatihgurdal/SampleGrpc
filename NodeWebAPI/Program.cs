using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NodeWebAPI
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
                    Common.EnvironmentVariableHelper.SetEnvironmentVariable(file); //Launch setting'de olan enviroment variable'larý atar
                }
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
