using System;
using System.Drawing;
using System.Windows.Forms;

namespace AOS2Ripper
{
    public static class Program
    {
        // TODO:
        // Add progress bar.
        // Test wrapping files.
        // Write readme.
        // Profit?
        public static SuGUI MainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm = new SuGUI();
            Application.Run(MainForm);
        }

        public static void WriteDebugText(string line)
        {
#if DEBUG
            Console.WriteLine(line);
#endif

            MainForm.AppendConsoleText(line);
        }

        public static void WriteDebugText(string line, Color color)
        {
#if DEBUG
            Console.WriteLine(line);
#endif

            MainForm.AppendConsoleText(line, color);
        }
    }
}
