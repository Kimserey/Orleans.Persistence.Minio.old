using Microsoft.Extensions.Logging;
using Orleans.Persistence.Minio.Samples.GrainInterfaces;
using System;
using System.Threading.Tasks;

namespace Orleans.Persistence.Minio.Samples.Client
{
    class Program
    {
        private static async Task<IClusterClient> StartClient()
        {
            var client = new ClientBuilder()
                .UseLocalhostClustering()
                .ConfigureApplicationParts(partManager => partManager.AddApplicationPart(typeof(IMySuperGrain).Assembly).WithReferences())
                .ConfigureLogging(logging => logging.AddConsole())
                .Build();

            await client.Connect();

            return client;
        }

        private static async Task<int> RunMainAsync()
        {
            using (var client = await StartClient())
            {
                await CallGrain(client);
                Console.ReadKey();
            }

            return 0;
        }
        private static async Task CallGrain(IClusterClient client)
        {
            var friend = client.GetGrain<IMySuperGrain>(0);

            var response = await friend.GetExistingGreeting();
            Console.WriteLine("\n\nExisting: {0}\n\n", response);

            response = await friend.SayHello("Good morning, my friend!");
            Console.WriteLine("\n\nSay Hello: {0}\n\n", response);
        }

        static int Main(string[] args)
        {
            return RunMainAsync().Result;
        }
    }
}
