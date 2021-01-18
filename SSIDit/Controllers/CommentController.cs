using Microsoft.AspNetCore.Mvc;
using SSIDit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        [HttpGet("new")]
        public IEnumerable<object> PushComment(int identity, int ssid, string content)
        {
            yield return Comment.New(identity, ssid, content);
        }

        [HttpGet("edit")]
        public IEnumerable<object> EditComment(int identity, int ssid, string oldContent, string newContent)
        {
            var comment = Comment.GetByConstant($"identity={identity} AND ssid={ssid} AND content=\"{oldContent}\"").FirstOrDefault();
            comment.Content = newContent;
            comment.Save();
            yield return comment;
        }

        [HttpGet("delete")]
        public IEnumerable<object> DeleteComment(int identity, int ssid, string content)
        {
            var comment = Comment.GetByConstant($"identity={identity} AND ssid={ssid} AND content=\"{content}\"").FirstOrDefault();
            comment.Delete();
            yield return Ok("Comment deleted.");
        }

        [HttpGet("get/all")]
        public IEnumerable<object> GetAll()
        {
            yield return Comment.GetAll();
        }

        [HttpGet("get/ssid/{id}")]
        public IEnumerable<object> GetBySsid(int ssid)
        {
            yield return Comment.GetBySsid(ssid);
        }

        [HttpGet("get/identity/{id}")]
        public IEnumerable<object> GetByIdentity(int identity)
        {
            yield return Comment.GetByIdentity(identity);
        }
    }
}
