using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
    public static class EnvironmentVariableHelper
    {
        /// <summary>
        /// Otomatik variable ataması
        /// </summary>
        public static void SetEnvironmentVariable(StreamReader file)
        {
            var reader = new JsonTextReader(file);
            var jObject = JObject.Load(reader);
            var variables = jObject
                .GetValue("profiles")
                .SelectMany(profiles => profiles.Children())
                .SelectMany(profile => profile.Children<JProperty>())
                .Where(prop => prop.Name == "environmentVariables")
                .SelectMany(prop => prop.Value.Children<JProperty>())
                .ToList();

            foreach (var variable in variables)
            {
                Environment.SetEnvironmentVariable(variable.Name, variable.Value.ToString());
            }

        }
    }
}
