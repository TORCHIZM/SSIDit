using SSIDit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SSIDit.Core
{
    public class AuthenticatableSSIDProxy
    {
        public IEnumerable<object> CreateSSID(string name)
        {
            var ssidList = SSID.GetAll();

            var ssid = ssidList.Where(x => x.Name == name).FirstOrDefault();

            if (ssid == null && IsValid(name))
                yield return SSID.New(name);
            else
                yield return new ErrorMessage("SSID already exists.");
        }

        /// <summary>
        /// Checks if given SSID is valid
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsValid(string name)
        {
            Regex r = new Regex("[a-z A-Z 0-9ıİçÇşŞğĞüÜöÖ._?'-]");
            return r.IsMatch(name);
        }
    }
}
