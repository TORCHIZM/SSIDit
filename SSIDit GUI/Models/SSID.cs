using SSIDit_GUI.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSIDit_GUI.Models
{
    public class SSID
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Vote> Votes { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public SSID()
        {
            Votes = new List<Vote>();
            Comments = new List<Comment>();
        }

        public void UpVote()
        {
            var _ = API.Post<Vote>($"vote/{VoteType.Up}", this);
        }

        public void DownVote()
        {
            var _ = API.Post<Vote>($"vote/{VoteType.Down}", this);
        }

        public void RevertVote()
        {
            var _ = API.Post<Vote>($"vote/{VoteType.Revert}", this);
        }

        public static async Task<List<SSID>> GetAll(FeedType feedType = FeedType.Feed)
        {
            Console.WriteLine($"ssid/{feedType}");
            return await API.Get<List<SSID>>($"ssid/{feedType}");
        }
    }
}
