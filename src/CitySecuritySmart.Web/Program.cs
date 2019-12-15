using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Google.Cloud.VideoIntelligence.V1;
using System;


namespace CitySecuritySmart.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>();
    }
}
