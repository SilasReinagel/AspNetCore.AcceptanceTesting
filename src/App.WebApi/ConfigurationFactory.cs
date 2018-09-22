using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace App.WebApi
{
    public static class ConfigurationFactory
    {
        public static IConfigurationRoot GetConfigurationRoot(
            string environment = null, 
            IEnumerable<KeyValuePair<string, string>> overrideValues = null)
        {
            var aspnetCoreEnvironment = environment ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Debug";
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{aspnetCoreEnvironment}.json", true)
                .AddInMemoryCollection(overrideValues ?? new List<KeyValuePair<string, string>>())
                .Build();
        }
    }
}
