using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace App.WebApi.Tests
{
    public static class TestContext
    {
#if Production
        private const string Environment = "Production";
#else
        private const string Environment = "Development";
#endif

        public static readonly HttpClient Client = TestClient(ConfigurationFactory.GetConfigurationRoot(Environment)).Value;
        
        private static Lazy<HttpClient> TestClient(IConfiguration config)
        {
            return new Lazy<HttpClient>(() =>
                new TestServer(new WebHostBuilder()
                        .UseConfiguration(config)
                        .UseStartup<Startup>())
                    .CreateClient());
        }
    }
}
