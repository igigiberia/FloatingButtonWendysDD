using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FloatingButtonWendysDD.Properties;

namespace FloatingButtonWendysDD
{
    public partial class ButtonForm : Form
    {
        public ButtonForm()
        {
            FormClosing += new System.Windows.Forms.FormClosingEventHandler(ButtonForm_FormClosing);
            InitializeComponent();
            DoWorkPollingTask();
        }
        private void ButtonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        void DoWorkPollingTask()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    this.BringToFront();
                    await Task.Delay(1000);
                }
            });
        }
        private void Exit()
        {
            FormClosing -= new System.Windows.Forms.FormClosingEventHandler(ButtonForm_FormClosing);
            Close();
        }
        private void ReloadServiceButton_Click(object sender, EventArgs e)
        {
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                string fullPath = string.Empty;
                foreach (var georgia in System.Diagnostics.Process.GetProcessesByName(Properties.Settings.Default.ProcessName))
                {
                    //if (string.IsNullOrEmpty(fullPath))
                    //    fullPath = georgia.GetMainModuleFileName();
                    georgia.Kill();
                }
                //if (!string.IsNullOrEmpty(fullPath))
                //    System.Diagnostics.Process.Start(fullPath);
                //else 
                if (File.Exists(Properties.Settings.Default.DefaultFilePath))
                    System.Diagnostics.Process.Start(Properties.Settings.Default.DefaultFilePath);
                else
                    MessageBox.Show("ვერ მოხერხდა სერვისის იდენტიფიკაცია", "ხარვეზი სერვისის გადატვირთვისას",
                        MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("სერვისის გადატვირთვა ვერ ხერხდება", "ხარვეზი სერვისის გადატვირთვისას",
                    MessageBoxButtons.OK);
            }
        }
    }
    internal static class Extensions
    {
        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        private static extern bool QueryFullProcessImageName([System.Runtime.InteropServices.In] IntPtr hProcess, 
                                                             [System.Runtime.InteropServices.In] uint dwFlags, 
                                                             [System.Runtime.InteropServices.Out] StringBuilder lpExeName, 
                                                             [System.Runtime.InteropServices.In, System.Runtime.InteropServices.Out] ref uint lpdwSize);

        public static string GetMainModuleFileName(this System.Diagnostics.Process process, int buffer = 1024)
        {
            var fileNameBuilder = new StringBuilder(buffer);
            uint bufferLength = (uint)fileNameBuilder.Capacity + 1;
            return QueryFullProcessImageName(process.Handle, 0, fileNameBuilder, ref bufferLength) ?
                fileNameBuilder.ToString() :
                null;
        }
    }
}
