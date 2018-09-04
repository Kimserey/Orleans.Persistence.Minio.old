using System.Threading.Tasks;

namespace Orleans.Persistence.Minio.Samples.GrainInterfaces
{
    public interface IMySuperGrain : IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);
    }
}
