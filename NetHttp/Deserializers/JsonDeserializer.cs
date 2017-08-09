using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetHttp.Deserializers
{
    public class JsonDeserializer : IDeserialize
    {
        public Newtonsoft.Json.JsonSerializer Serializer {get;set;} = JsonSerializer.Create();
        public Task<T> Deserialize<T>(string content)
        {
            return Task.FromResult(Serializer.Deserialize<T>(new JsonTextReader(new StringReader(content))));
        }
    }
}