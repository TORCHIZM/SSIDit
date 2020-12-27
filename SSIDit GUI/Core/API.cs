using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace SSIDit_GUI.Core
{
    public static class API
    {
        public static HttpClient Client = new HttpClient();
        public const string ApiPath = "https://localhost:5001/api";

        public static async Task<T> Get<T>(string path, string query = "")
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"{ApiPath}/{path}?{query}");
            var response = await Client.SendAsync(request);
            var message = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(message);
        }
    }
}
