using Orleans.Persistence.Minio.Samples.GrainInterfaces;
using System.Threading.Tasks;

namespace Orleans.Persistence.Minio.Samples.Grains
{
    public class MySuperGrain : Grain, IMySuperGrain
    {
        public Task<string> SayHello(string greeting)
        {
            return Task.FromResult($"You said: '{greeting}', I say: Hello!");
        }
    }
}
