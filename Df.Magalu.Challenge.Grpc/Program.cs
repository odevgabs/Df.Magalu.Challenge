using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace Df.Magalu.Challenge.Grpc
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
                  webBuilder
                      .ConfigureKestrel(c =>
                      {
                          c.Listen(IPEndPoint.Parse("0.0.0.0:5000"), l => l.Protocols = HttpProtocols.Http2);
                      })
                      .UseStartup<Startup>();
              });

    }
}
