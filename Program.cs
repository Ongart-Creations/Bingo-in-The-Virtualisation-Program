using System;
using System.Windows.Forms;

namespace Bingo
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!System.Diagnostics.Debugger.IsAttached)
            {
                Application.ThreadException += Application_ThreadException;
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            }

            Application.Run(new BingoMainMenu());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An critical error occurred.", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            GC.Collect();
            Environment.Exit(0);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("An critical error occurred.\n\nPlease report this to the developer:\n\n" + e.Exception.StackTrace, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            GC.Collect();
            Environment.Exit(0);
        }
    }
}
