using System.Threading.Tasks;

namespace NetHttp.Deserializers
{
    public interface IDeserialize
    {
        Task<T> Deserialize<T>(string content);        
    }
}