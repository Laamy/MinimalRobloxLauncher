using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Web;
using System.Windows.Forms;

using Microsoft.Win32;

namespace MinimalRobloxLauncher
{
    internal class Program
    {
        static void ReplaceKey(string app)
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey($"{app}\\shell\\open\\command", true);
            key.SetValue(string.Empty,
                $"\"{AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.FriendlyName}\" %1");
            key.Close();
        }

        static void Main(string[] args)
        {
            if (args.Length == 0 && new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                ReplaceKey("roblox-player");
                MessageBox.Show("Process replaced", "Success");
            }
            else
            {
                var la = Launcher.ParseArgs(args[0]);

                // https://clientsettingscdn.roblox.com/v2/client-version/WindowsPlayer

                var robloxVersions = Directory.GetDirectories("C:\\Program Files (x86)\\Roblox\\Versions");

                Process proc = Process.Start(robloxVersions[robloxVersions.Length - 1] + "\\RobloxPlayerBeta.exe",
                    $"--play -a https://www.roblox.com/Login/Negotiate.ashx -t {la.Gameinfo} " +
                    $"-j {HttpUtility.UrlDecode(la.PlaceLauncherUrl)} -b {la.BrowserTrackerID} --launchtime={la.LaunchTime} " +
                    $"--rloc {la.RobloxLocale} --gloc {la.GameLocale}");

                Console.ReadLine();
            }
        }
    }
}
