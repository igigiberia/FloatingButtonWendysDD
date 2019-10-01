using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;

   
namespace FloatingButtonWendysDD
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                bool isElevated;
                using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
                {
                    WindowsPrincipal principal = new WindowsPrincipal(identity);
                    isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
                if (!isElevated)
                {
                    var SelfProc = new System.Diagnostics.ProcessStartInfo
                    {
                        UseShellExecute = true,
                        WorkingDirectory = Environment.CurrentDirectory,
                        FileName = Application.ExecutablePath,
                        Verb = "runas"
                    };
                    System.Diagnostics.Process.Start(SelfProc);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var StartX = Properties.Settings.Default.ButtonWidth == 0 || Properties.Settings.Default.Left ? 0 : Screen.PrimaryScreen.WorkingArea.Width - Properties.Settings.Default.ButtonWidth;
                var StartY = Properties.Settings.Default.ButtonHeight == 0 || Properties.Settings.Default.Top ? 0 : Screen.PrimaryScreen.WorkingArea.Height - Properties.Settings.Default.ButtonHeight;
                var ButtonWidth = Properties.Settings.Default.ButtonWidth == 0 ? Screen.PrimaryScreen.WorkingArea.Width : Properties.Settings.Default.ButtonWidth;
                var ButtonHeight = Properties.Settings.Default.ButtonHeight == 0 ? Screen.PrimaryScreen.WorkingArea.Height : Properties.Settings.Default.ButtonHeight;
                var customLocation = new Point(StartX,StartY);
                Application.Run(new ButtonForm()
                {
                    MinimizeBox = false,
                    MaximizeBox = false,
                    ControlBox = false,
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    Width = ButtonWidth,
                    Height = ButtonHeight,
                    StartPosition = FormStartPosition.Manual,
                    Location = customLocation,
                    TopMost = true,
                    TopLevel = true,
                    ShowInTaskbar = false
                });
            }
            catch
            {
                MessageBox.Show("ვერ მოხერხდა პროგრამის გაშვება ადმინისტრატორის უფლებებით", "ხარვეზი",
                    MessageBoxButtons.OK);
            }
        }
    }
}
