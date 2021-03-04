using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

using SSIDit_GUI.Models;

namespace SSIDit_GUI.Core
{
    public class SSIDController
    {
        public async void CreateSSID(string name)
        {
            if (IsValid(name))
                await API.Get<SSID>("ssid/new", $"name={name}");
            else
                MessageBox.Show($"SSID {name} can not requires our name standarts.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
