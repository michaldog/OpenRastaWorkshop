using System.IO;
using System.Text;
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
}