using Microsoft.Extensions.Logging;
using Orleans.Hosting;
using Orleans.Persistence.Minio.Samples.Grains;
using System;

namespace Orleans.Persistence.Minio.Samples.Silo
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new SiloHostBuilder()
                .UseLocalhostClustering()
                .AddMinioGrainStorage("minio", options =>
                {
                    options.AccessKey = "";
                    options.SecretKey = "";
                    options.Endpoint = "localhost:9000";
                    options.Container = "grain-storage";
                })
                .ConfigureApplicationParts(partManager => partManager.AddApplicationPart(typeof(MySuperGrain).Assembly).WithReferences())
                .ConfigureLogging(logging => logging.AddConsole())
                .Build();

            host.StartAsync().Wait();
            Console.WriteLine("Silo started");
            Console.ReadKey();
        }
    }
}
