using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
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

        public static async Task<T> Post<T>(string path, object obj = null, string query = "")
        {
            string autoQuery = "";

            if (obj == null) goto NoObject;

            PropertyInfo[] array = obj.GetType().GetProperties().Where(x => x.GetValue(obj, null).GetType() != typeof(DateTime)).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                PropertyInfo prop = array[i];

                if (prop.Name != "ID")
                {
                    autoQuery += $"{prop.Name.ToLower()}={prop.GetValue(obj, null)}";

                    if (prop.Name != array.Last().Name)
                        autoQuery+= "&";
                }
            }

            NoObject:

            var request = new HttpRequestMessage(new HttpMethod("POST"), $"{ApiPath}/{path}?{autoQuery}{query}");
            var response = await Client.SendAsync(request);
            var message = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(message);
        }

        public static async Task<T> Delete<T>(string path, object obj = null, string query = "")
        {
            string autoQuery = "";

            if (obj == null) goto NoObject;

            PropertyInfo[] array = obj.GetType().GetProperties().Where(x => x.GetValue(obj, null).GetType() != typeof(DateTime)).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                PropertyInfo prop = array[i];

                if (prop.Name != "ID")
                {
                    autoQuery += $"{prop.Name.ToLower()}={prop.GetValue(obj, null)}";

                    if (prop.Name != array.Last().Name)
                        autoQuery += "&";
                }
            }

            NoObject:

            var request = new HttpRequestMessage(new HttpMethod("DELETE"), $"{ApiPath}/{path}?{autoQuery}{query}");
            var response = await Client.SendAsync(request);
            var message = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(message);
        }
    }
}
