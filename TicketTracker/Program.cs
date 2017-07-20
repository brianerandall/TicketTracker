using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketTracker
{
    static class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var dataDirectory = @"..\Data\TicketTracker.mdf" + Application.StartupPath;
            var absolutePath = Path.GetFullPath(dataDirectory);

            AppDomain.CurrentDomain.SetData("DataDirectory", absolutePath);
            Application.Run(new frmMain());
        }       
    }
}
