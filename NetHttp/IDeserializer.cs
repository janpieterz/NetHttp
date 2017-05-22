using System.IO;
using System.Threading.Tasks;

namespace NetHttp
{
    public interface IDeserializer
    {
        Task<T> Deserialize<T>(Stream stream);
    }
}