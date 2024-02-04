using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBlock
{
    public class IBlock
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        private static void CheckFile()
        {
            try
            {
                if (!File.Exists("file.txt"))
                {
                    File.Create("file.txt");
                }
                if (!File.Exists("file2.txt"))
                {
                    File.Create("file2.txt");
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [STAThread]
        public static void Main()
        {
            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool administrativeMode = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (!administrativeMode)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.Verb = "runas";
                startInfo.FileName = Application.ExecutablePath;
                try
                {
                    Process.Start(startInfo);
                }
                catch
                {
                    return;
                }
                return;
            }
            CheckFile();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
