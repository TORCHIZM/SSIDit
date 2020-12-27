using Microsoft.AspNetCore.Mvc;
using SSIDit.Models;
using System.Collections.Generic;
using System.Linq;

namespace SSIDit.Controllers
{
    [ApiController]
    [Route("api/ssid")]
    public class SSIDController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<object> GetSSIDList()
        {
            return SSID.GetAll();
        }

        [HttpGet("feed")]
        public IEnumerable<object> GetSSIDListByDate()
        {
            var ssidList = SSID.GetAll();
            ssidList.Reverse();
            return ssidList;
        }

        [HttpGet("upvote")]
        public IEnumerable<object> GetSSIDListByUpvote()
        {
            var ssidList = SSID.GetAll();
            var SortedList = ssidList.OrderBy(o => o.Votes.Where(x => x.Type == 1).ToList().Count).ToList();
            SortedList.Reverse();

            yield return SortedList;
        }

        [HttpGet("downvote")]
        public IEnumerable<object> GetSSIDListByDownvote()
        {
            var ssidList = SSID.GetAll();
            var SortedList = ssidList.OrderBy(o => o.Votes.Where(x => x.Type == 0).ToList().Count).ToList();
            SortedList.Reverse();

            yield return SortedList;
        }

        [HttpGet("{id}")]
        public IEnumerable<object> GetSSIDByID(int id)
        {
            var ssid = SSID.Get(id);
            if (ssid == null) yield return NotFound();
            yield return ssid;
        }

        [HttpGet("new")]
        public IEnumerable<object> PushSSID(string name)
        {
            var ssidList = SSID.GetAll();

            var ssid = ssidList.Where(x => x.Name == name).FirstOrDefault();

            if (ssid == null)
                yield return SSID.New(name);
            else
                yield return new ErrorMessage("SSID already exists.");
        }
    }
}
