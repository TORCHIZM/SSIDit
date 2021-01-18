using SSIDit.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SSIDit.Models
{
    public class Comment : IModel
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int Identity { get; set; }
        public int Ssid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Comment()
        {
        }

        public Comment(int identity, int ssid, string content)
        {
            this.Identity = identity;
            this.Ssid = ssid;
            this.Content = content;
        }

        public void Delete()
        {
            MySQL.Execute($"DELETE FROM comments WHERE id={ID}");
        }

        public void Save()
        {
            MySQLCommands.Update(this);
        }

        public static Comment New(int identity, int ssid, string content)
        {
            MySQLCommands.Insert(new Comment(identity, ssid, content));
            return new Comment(identity, ssid, content);
        }

        public static Comment GetById(int id)
        {
            var response = MySQL.Select<Comment>($"SELECT * FROM comments WHERE id={id}").FirstOrDefault();
            return response;
        }

        public static List<Comment> GetByIdentity(int identity)
        {
            var response = MySQL.Select<Comment>($"SELECT * FROM comments WHERE identity={identity}");
            return response;
        }

        public static List<Comment> GetBySsid(int ssid)
        {
            var response = MySQL.Select<Comment>($"SELECT * FROM comments WHERE ssid={ssid}");
            return response;
        }
        public static List<Comment> GetByConstant(string constant)
        {
            var response = MySQL.Select<Comment>($"SELECT * FROM comments WHERE {constant}");
            return response;
        }

        public static List<Comment> GetAll()
        {
            var response = MySQL.Select<Comment>("SELECT * FROM comments");
            return response;
        }
    }
}
