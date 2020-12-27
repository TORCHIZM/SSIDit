using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SSIDit.Models
{
    public class SSID
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Votes> Votes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Parameterless constructor for System.Active class
        public SSID()
        {
            this.Votes = new List<Votes>();
        }

        public SSID(string name)
        {
            Name = name;
            this.Votes = new List<Votes>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void Save()
        {
            string properties = "";

            foreach (PropertyInfo prop in GetType().GetProperties())
                if (prop.GetValue(this, null).GetType() != typeof(DateTime))
                    properties += prop.GetValue(this, null).GetType() == typeof(int) ? $"{prop.Name}={prop.GetValue(this, null)}," : $"{prop.Name}=\"{prop.GetValue(this, null)}\",";

            properties += "ID=ID";

            Database.MySQL.Execute($"UPDATE ssid SET {properties} WHERE id={this.ID}");
        }

        public void UpVote(int identity)
        {
            this.Votes.Add(Models.Votes.New(identity, ID, 1));
        }

        public void DownVote(int identity)
        {
            var vote = this.Votes.Where(x => x.Identity == identity && x.Type == 0).FirstOrDefault();
            this.Votes.Remove(vote);
            vote.Delete();
        }

        public static List<SSID> GetAll()
        {
            var ssidList = Database.MySQL.Select<SSID>("SELECT * FROM ssid");
            var votelist = Models.Votes.GetAll();

            votelist.ForEach(x =>
            {
                ssidList.Where(y => y.ID == x.Ssid).Select(x => x).FirstOrDefault().Votes.Add(x);
            });

            return ssidList;
        }

        public static SSID Get(int id)
        {
            var votes = Models.Votes.GetBySSID(id);
            var ssid = Database.MySQL.Select<SSID>($"SELECT * FROM ssid WHERE id={id}").FirstOrDefault();
            ssid.Votes = votes;
            return ssid;
        }

        public static SSID New(string name)
        {
            Database.MySQL.Execute($"INSERT INTO ssid (name) VALUES (\"{name}\")");
            return new SSID(name);
        }
    }
}
