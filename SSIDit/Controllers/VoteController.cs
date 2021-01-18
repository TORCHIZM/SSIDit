using Microsoft.AspNetCore.Mvc;
using SSIDit.Models;
using System.Collections.Generic;
using System.Linq;

namespace SSIDit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        [HttpGet("up")]
        public IEnumerable<object> UpVote(int id, int identity)
        {
            var vote = Vote.GetBySSID(identity, id).FirstOrDefault();

            if (vote == null)
                yield return Vote.New(identity, id, 1);
            else
            {
                vote.Delete();
                yield return Ok("Upvote deleted.");
            }
        }

        [HttpGet("down")]
        public IEnumerable<object> DownVote(int identity, int id)
        {
            var vote = Vote.GetBySSID(identity, id).FirstOrDefault();

            if (vote == null)
                yield return Vote.New(identity, id, 0);
            else
            {
                vote.Delete();
                yield return Ok("Downvote deleted.");
            }
        }

        [HttpGet("revert")]
        public IEnumerable<object> RevertVote(int identity, int id)
        {
            var vote = Vote.GetBySSID(identity, id).FirstOrDefault();

            if (vote == null)
                yield return Ok("Vote not found");
            else
            {
                vote.Type = (vote.Type == 1) ? 0 : 1;
                vote.Save();
                yield return vote;
            }
        }
    }
}
