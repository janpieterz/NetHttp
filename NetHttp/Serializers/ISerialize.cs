using System.Threading.Tasks;

namespace NetHttp.Serializers{
    public interface ISerialize{
        Task<string> Serialize(object @object);
        string ContentType {get;set;}
    }
}