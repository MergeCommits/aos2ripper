using System;
using System.Windows.Forms;

namespace AOS2Ripper
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            string uh = "u73$@STKY%&F#K;;zZTY%JM2@{}}1HsdbtyJU+g2j9ZXSc;32<%&v#&>_vDHYwQWJKIJs67?*e'-wBJ3#!)FVh!)O";
            for (int i = 0; i < uh.Length; i++)
            {
                Console.Write("'" + uh[i] + "', ");
            }
            Console.ReadKey();
        }
    }
}
