using SSIDit.Database;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SSIDit.Models
{
    public class Vote : IModel
    {
        public int ID { get; set; }
        public int Identity { get; set; }
        public int Ssid { get; set; }
        public int Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Vote()
        {
        }

        public Vote(int identity, int ssid, int type)
        {
            Identity = identity;
            Ssid = ssid;
            Type = type;
        }

        public void Delete()
        {
            MySQLCommands.Delete(this);
        }

        public void Save()
        {
            MySQLCommands.Update(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ssid"></param>
        /// <param name="type">0 = Downvote, 1 = Upvote</param>
        /// <param name="identity"></param>
        public static Vote New(int identity, int ssid, int type)
        {
            var vote = new Vote(identity, ssid, type);
            MySQLCommands.Insert(vote);
            return vote;
        }

        public static List<Vote> GetAll()
        {
            return MySQLCommands.Select<Vote>("SELECT * FROM votes");
        }

        public static List<Vote> GetBySSID(int id)
        {
            return MySQLCommands.Select<Vote>($"SELECT * FROM votes WHERE ssid={id}");
        }

        public static List<Vote> GetBySSID(int identity, int id)
        {
            return MySQLCommands.Select<Vote>($"SELECT * FROM votes WHERE Ssid={id} AND Identity={identity}");
        }
    }
}
