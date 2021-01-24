using System;

namespace SSIDit_GUI.Models
{
    public class Vote
    {
        public int ID { get; set; }
        public int Identity { get; set; }
        public int Ssid { get; set; }
        public int Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
