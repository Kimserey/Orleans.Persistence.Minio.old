using Orleans.Persistence.Minio.Samples.GrainInterfaces;

namespace Orleans.Persistence.Minio.Samples.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ClientBuilder()
                .UseLocalhostClustering()
                .ConfigureApplicationParts(partManager => partManager.AddApplicationPart(typeof(IMySuperGrain).Assembly).WithReferences())
                .Build();

            client.Connect().Wait();
        }
    }
}
