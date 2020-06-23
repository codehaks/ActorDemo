using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Hosting;

namespace WebApp
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
                    webBuilder.UseStartup<Startup>();
                }).UseOrleans(siloBuilder =>
                {
                    siloBuilder
                    .UseLocalhostClustering()
                    //.UseSignalR().AddMemoryGrainStorage("PubSubStore")
                    
                    //.AddAdoNetGrainStorage("messageStore", options =>
                    //{
                    //    options.Invariant = "System.Data.SqlClient";
                    //    options.ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=OrleansDemo;Integrated Security=True";
                    //    options.UseJsonFormat = true;
                    //})
                     .AddAdoNetGrainStorage("statusStore", options =>
                      {
                          options.Invariant = "System.Data.SqlClient";
                          options.ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=OrleansDemo;Integrated Security=True";
                          options.UseJsonFormat = true;
                      })
                      .AddAdoNetGrainStorage("sensorStore", options =>
                      {
                          options.Invariant = "System.Data.SqlClient";
                          options.ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=OrleansDemo;Integrated Security=True";
                          options.UseJsonFormat = true;
                      });
                });
    }
}
