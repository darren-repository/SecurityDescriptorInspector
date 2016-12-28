using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//Security Related
using System.Security;
using System.Security.Claims;
using System.Security.Principal;

//Process Related
using System.Diagnostics;

namespace SecurityDescriptorInspector
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Check to see if running in elevated mode
            WindowsIdentity myIdentity = WindowsIdentity.GetCurrent();
            WindowsPrincipal myPrinciple = new WindowsPrincipal(myIdentity);

            if (myPrinciple.IsInRole(WindowsBuiltInRole.Administrator) == false)
            {
                ProcessStartInfo restartElevated = new ProcessStartInfo();

                restartElevated.UseShellExecute = true;
                restartElevated.WorkingDirectory = Environment.CurrentDirectory;
                restartElevated.FileName = Application.ExecutablePath;
                restartElevated.Verb = "runas";

                try
                {
                    Process.Start(restartElevated);
                    Environment.Exit(0);
                }
                catch
                {
                    Console.WriteLine("failed to start a new instance elevated, continuing to run unelevated");
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
