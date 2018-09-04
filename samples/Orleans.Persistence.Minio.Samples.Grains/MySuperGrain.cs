using Orleans.Persistence.Minio.Samples.GrainInterfaces;
using Orleans.Providers;
using System.Threading.Tasks;

namespace Orleans.Persistence.Minio.Samples.Grains
{
    [StorageProvider(ProviderName = "minio")]
    public class MySuperGrain : Grain<MySuperGrainState>, IMySuperGrain
    {
        public async Task<string> SayHello(string greeting)
        {
            State.Greeting = greeting;
            await WriteStateAsync();
            return $"You said: '{greeting}', I say: Hello!";
        }

        public Task<string> GetExistingGreeting()
        {
            return Task.FromResult(State.Greeting);
        }
    }

    public class MySuperGrainState
    {
        public string Greeting { get; set; }
    }
}
