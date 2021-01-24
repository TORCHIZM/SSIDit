using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SSIDit.Attributes;
using SSIDit.Controllers;
using SSIDit.Models;
using SSIDit.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace SsidItTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestCommentController()
        {
            //Console.WriteLine(AttributeController.GetColumnName(typeof(SSID).GetProperty("sdgds")));
            var a = AttributeController.GetAttributeValue<string, ColumnName>(typeof(SSID).GetProperty("CreatedAt"), "Name");
            Console.WriteLine(a);
        }

        public static Dictionary<string, bool> GetAttrs()
        {
            Dictionary<string, bool> _dict = new Dictionary<string, bool>();

            PropertyInfo[] props = typeof(SSID).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    IncludeColumn authAttr = attr as IncludeColumn;
                    if (authAttr != null)
                    {
                        string propName = prop.Name;
                        bool auth = authAttr.Include;

                        _dict.Add(propName, auth);
                    }
                }
            }

            return _dict;
        }
    }
}
