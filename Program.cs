﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .UseUrls("http://localhost:4000")
                        .UseKestrel(options =>
                        {
                            options.Limits.MaxRequestBodySize = 152428800;
                        }).UseHttpSys( options => {
                            options.MaxRequestBodySize = 152428800;
                        })
                        
                        ;
                });
    }
}
