using SSIDit.Attributes;
using SSIDit.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SSIDit.Models
{
    public class SSID : IModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [IncludeColumn(false)]
        public List<Vote> Votes { get; set; }
        [IncludeColumn(false)]
        public List<Comment> Comments { get; set; }

        [ColumnName("created_at")]
        public DateTime CreatedAt { get; set; }
        [ColumnName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public SSID()
        {
            this.Votes = new List<Vote>();
            this.Comments = new List<Comment>();
        }

        public SSID(string name)
        {
            Name = name;
            this.Votes = new List<Vote>();
            this.Comments = new List<Comment>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void Save()
        {
            MySQLCommands.Update(this);
        }

        public void Delete()
        {
            MySQLCommands.Delete(this);
        }

        public static SSID New(string name)
        {
            var ssid = new SSID(name);
            MySQLCommands.Insert(ssid);
            return ssid;
        }

        public void UpVote(int identity)
        {
            this.Votes.Add(Vote.New(identity, ID, 1));
        }

        public void DownVote(int identity)
        {
            var vote = this.Votes.Where(x => x.Identity == identity && x.Type == 0).FirstOrDefault();
            this.Votes.Remove(vote);
            vote.Delete();
        }

        public static List<SSID> GetAll()
        {
            var ssidList = MySQLCommands.Select<SSID>("SELECT * FROM ssids");
            var votelist = Vote.GetAll();

            votelist.ForEach(x =>
            {
                ssidList.Where(y => y.ID == x.Ssid).FirstOrDefault().Votes.Add(x);
            });

            return ssidList;
        }

        public static SSID Get(int id)
        {
            var votes = Vote.GetBySSID(id);
            var ssid = MySQLCommands.Select<SSID>($"SELECT * FROM ssids WHERE id={id}").FirstOrDefault();
            ssid.Votes = votes;
            return ssid;
        }
    }
}
