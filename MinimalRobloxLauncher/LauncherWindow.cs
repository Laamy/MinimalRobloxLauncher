using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MinimalRobloxLauncher
{
    public partial class LauncherWindow : Form
    {
        public LauncherWindow() => InitializeComponent();

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Process proc in Process.GetProcesses())
                if (proc.MainWindowTitle == "Roblox")
                    Process.GetCurrentProcess().Kill();
        }
        private void LauncherWindow_FormClosing(object sender, FormClosingEventArgs e) => Process.GetCurrentProcess().Kill(); // avoid it staying in process list
    }
}
