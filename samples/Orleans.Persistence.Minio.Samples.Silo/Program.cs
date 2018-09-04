using Orleans.Hosting;
using Orleans.Persistence.Minio.Samples.Grains;

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
                    options.Endpoint = "";
                    options.Container = "grain-storage";
                })
                .ConfigureApplicationParts(partManager => partManager.AddApplicationPart(typeof(MySuperGrain).Assembly).WithReferences())
                .Build();

            host.StartAsync();
        }
    }
}
