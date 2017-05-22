using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetHttp
{
    public class JsonDeserializer : IDeserializer
    {
        private readonly JsonSerializer _serializer = JsonSerializer.Create();
        public Task<T> Deserialize<T>(string content)
        {
            return Task.FromResult(_serializer.Deserialize<T>(new JsonTextReader(new StringReader(content))));
        }
    }
}