using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SSIDit_GUI.Models
{
    public class AccessPoint
    {
        public string SSID { get; set; }
        public string BSSID { get; set; }
        public byte Signal { get; set; }

        public static async Task<AccessPoint[]> GetSignalOfNetworks()
        {
            string result = await ExecuteProcessAsync(@"C:\Windows\System32\netsh.exe", "wlan show networks mode=bssid");

            return Regex.Split(result, @"[^B]SSID \d+").Skip(1).SelectMany(network => GetAccessPointFromNetwork(network)).ToArray();
        }

        public static AccessPoint[] GetAccessPointFromNetwork(string network)
        {
            string withoutLineBreaks = Regex.Replace(network, @"[\r\n]+", " ").Trim();
            string ssid = Regex.Replace(withoutLineBreaks, @"^:\s+(\S+).*$", "$1").Trim();

            return Regex.Split(withoutLineBreaks, @"\s{4}BSSID \d+").Skip(1).Select(ap => GetAccessPoint(ssid, ap)).ToArray();
        }

        public static AccessPoint GetAccessPoint(string ssid, string ap)
        {
            string withoutLineBreaks = Regex.Replace(ap, @"[\r\n]+", " ").Trim();
            string bssid = Regex.Replace(withoutLineBreaks, @"^:\s+([a-f0-9]{2}(:[a-f0-9]{2}){5}).*$", "$1").Trim();
            byte signal = byte.Parse(Regex.Replace(withoutLineBreaks, @"^.*(Signal|Sinal)\s+:\s+(\d+)%.*$", "$2").Trim());

            return new AccessPoint
            {
                SSID = ssid,
                BSSID = bssid,
                Signal = signal,
            };
        }

        public static async Task<string> ExecuteProcessAsync(string cmd, string args = null)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = cmd,
                    Arguments = args,
                    RedirectStandardInput = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8,
                }
            };

            process.Start();

            string result = await process.StandardOutput.ReadToEndAsync();

            process.WaitForExit();

            return result;
        }

        private static void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}
