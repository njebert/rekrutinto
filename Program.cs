using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

//https://github.com/Microsoft/generator-docker
//https://medium.com/@arunoda/production-quality-mongodb-setup-with-docker-65136a4a9d8
//https://coding4dummies.net/load-balanced-asp-net-core-application-with-docker-mongodb-and-redis-pt-4-825cb5f37241
//https://kieldev.wordpress.com/2017/02/25/deploying-an-angular-2-net-core-1-1-web-api-and-mongodb-using-docker-containers/

namespace rekrutinto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
