using System.IO;

namespace AOS2Ripper.Parsers
{
    public class PakManager
    {
        private string zipPath;
        private string dir;

        public PakManager(string uh1, string uh2)
        {
            zipPath = uh1;
            dir = uh2;
        }

        public string Pak2Folder()
        {
            if (!Directory.Exists(dir))
            {
                return "Specified directory doesn't exist!";
            }

            if (!File.Exists(zipPath))
            {
                return "Specified file doesn't exist!";
            }


        }
    }
}
