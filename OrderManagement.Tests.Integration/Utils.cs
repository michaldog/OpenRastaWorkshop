using System.IO;
using System.Text;
using Newtonsoft.Json;
using OpenRasta.Hosting.InMemory;
using OpenRasta.Web;

static internal class Utils
{
    public static HttpEntity GetHttpEntity(InMemoryRequest postRequest, string data, MediaType MediaType)
    {
        var bytes = Encoding.UTF8.GetBytes(data);
        var httpEntity = new HttpEntity(postRequest.Entity.Headers, new MemoryStream(bytes)) { ContentLength = bytes.Length };
        httpEntity.ContentType = MediaType;
        return httpEntity;
    }

    public static string GetJsonFromObject(dynamic obj)
    {
        var jsonSerializer = new JsonSerializer();
        using (var stringWriter = new StringWriter())
        {
            jsonSerializer.Serialize(stringWriter, obj);
            var stringBuilder = stringWriter.GetStringBuilder();
            return stringBuilder.ToString();
        }
    }

    public static dynamic GetResultFromJson(IResponse response)
    {
        var stream = response.Entity.Stream;
        stream.Position = 0;
        using (var streamReader = new StreamReader(stream))
        {
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                var jsonSerializer = new JsonSerializer();
                dynamic json = jsonSerializer.Deserialize(jsonTextReader);
                return json;
            }
        }
    }
}