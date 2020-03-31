using System;
using System.Drawing;
using System.Windows.Forms;

namespace AOS2Ripper
{
    public static class Program
    {
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

        public static void WriteDebugText(string line, Color color)
        {
#if DEBUG
            Console.WriteLine(line);
#endif

            if (color == Color.Black)
            {
                MainForm.AppendConsoleText(line);
            }
            else
            {
                MainForm.AppendConsoleText(line, color);
            }
        }

        public static void WriteDebugText(string line) => WriteDebugText(line, Color.Black);
    }
}
