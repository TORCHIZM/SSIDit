using SSIDit_GUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSIDit_GUI.Models
{
    public class SSID
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Votes> Votes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public SSID()
        {
            Votes = new List<Votes>();
        }

        public void UpVote()
        {
            var _ = API.Get<Votes>("vote/up", $"id={ID}&identity={Utils.ID}");
        }

        public void DownVote()
        {
            var _ = API.Get<Votes>("vote/down", $"id={ID}&identity={Utils.ID}");
        }

        public void RevertVote()
        {
            var _ = API.Get<Votes>("vote/revert", $"id={ID}&identity={Utils.ID}");
        }
    }
}
