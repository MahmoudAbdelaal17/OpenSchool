// ---------------------------------------------------------------
// Copyright (c) OpenSchool Teams 
// FREE TO USE TO School System 
// ---------------------------------------------------------------


using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace OpenSchool.Web.Api
{
    public class Program
    {
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
