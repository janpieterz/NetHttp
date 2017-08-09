using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetHttp.Serializers {
    public class JsonSerializer : ISerialize
    {
        public string ContentType { get ; set; } = "application/json";
        public Newtonsoft.Json.JsonSerializer Serializer {get;set;} = Newtonsoft.Json.JsonSerializer.Create();
        public Task<string> Serialize(object @object)
        {
            using(StringWriter sw =  new StringWriter()){
                Serializer.Serialize(sw, @object);
                return Task.FromResult(sw.ToString());
            }                        
        }
    }
}