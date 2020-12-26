using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SSIDit.Models
{
    public class Votes
    {
        public int ID { get; set; }
        public int Identity { get; set; }
        public int Ssid { get; set; }
        public int Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Parameterless constructor for System.Active class
        public Votes()
        {
        }

        public Votes(int identity, int ssid, int type)
        {
            Identity = identity;
            Ssid = ssid;
            Type = type;
        }

        public void Delete()
        {
            Database.MySQL.Execute($"DELETE FROM votes WHERE ssid={Ssid} AND type={Type} AND identity={Identity}");
        }

        public void Save()
        {
            string properties = "";

            foreach (PropertyInfo prop in GetType().GetProperties())
                if (prop.GetValue(this, null).GetType() != typeof(DateTime))
                    properties += prop.GetValue(this, null).GetType() == typeof(int) ? $"{prop.Name}={prop.GetValue(this, null)}," : $"{prop.Name}=\"{prop.GetValue(this, null)}\",";

            properties += "ID=ID";

            Database.MySQL.Execute($"UPDATE votes SET {properties} WHERE id={this.ID}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ssid"></param>
        /// <param name="type">0 = Downvote, 1 = Upvote</param>
        /// <param name="identity"></param>
        public static Votes New(int identity, int ssid, int type)
        {
            Database.MySQL.Execute($"INSERT INTO votes (Identity, Ssid, Type) VALUES ({identity}, {ssid}, {type})");

            return new Votes(identity, ssid, type);
        }

        public static List<Votes> GetAll()
        {
            return Database.MySQL.Select<Votes>("SELECT * FROM votes");
        }

        public static List<Votes> GetBySSID(int id)
        {
            return Database.MySQL.Select<Votes>($"SELECT * FROM votes WHERE ssid={id}");
        }

        public static List<Votes> GetBySSID(int identity, int id)
        {
            return Database.MySQL.Select<Votes>($"SELECT * FROM votes WHERE Ssid={id} AND Identity={identity}");
        }
    }
}
