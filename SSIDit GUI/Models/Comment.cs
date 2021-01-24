using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSIDit_GUI.Models
{
    [JsonObject]
    public class Comment
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("identity")]
        public int Identity { get; set; }
        [JsonProperty("ssid")]
        public int Ssid { get; set; }
        [JsonProperty("createdat")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updatedat")]
        public DateTime UpdatedAt { get; set; }
    }
}
