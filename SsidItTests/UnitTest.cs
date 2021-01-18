using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SSIDit;
using SSIDit.Controllers;
using SSIDit.Database;
using SSIDit.Models;
using System;

namespace SsidItTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestCommentController()
        {
            var controller = new CommentController();

            var bySsid = controller.GetBySsid(1);
            Console.WriteLine(JsonConvert.SerializeObject(bySsid));

            var byIdentity = controller.GetByIdentity(2);
            Console.WriteLine(JsonConvert.SerializeObject(byIdentity));

            var all = controller.GetAll();
            Console.WriteLine(JsonConvert.SerializeObject(all));
        }
    }
}
