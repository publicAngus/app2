using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace app2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Main started with below args:");
            Console.WriteLine(string.Join(",",args));
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args){

        var configs = new ConfigurationBuilder()
        .AddCommandLine(args)
        .Build();
        

         return  WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //.UseContentRoot(Directory.GetCurrentDirectory())
                //.UseUrls("http://localhost:9001")
                //.UseConfiguration(configs)
                //.ConfigureAppConfiguration((builderCtx,config)=>{
                    //IHostingEnvironment env = builderCtx.HostingEnvironment;
                    //config.AddJsonFile("appsettings.json",false,true)
                    //.AddJsonFile($"appsettings.{env.EnvironmentName}.json",true,true);
                //})  
                .Build();
        }
        
    }
}
