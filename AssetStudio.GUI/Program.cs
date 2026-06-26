using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetStudio.GUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (_, args) => ShowFatalError(args.Exception);
            AppDomain.CurrentDomain.UnhandledException += (_, args) => ShowFatalError(args.ExceptionObject as Exception);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void ShowFatalError(Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            MessageBox.Show(
                exception.ToString(),
                "AssetStudio startup error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}