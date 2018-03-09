using System.IO;
using System.IO.Compression;

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

            ZipFile.ExtractToDirectory(zipPath, dir);

            string[] foils = Directory.GetFiles(dir, "*" + Constants.DAT_EXT, SearchOption.AllDirectories);
            foreach (string file in foils)
            {
                string fileNoExt = file.Substring(file.Length - (Constants.DAT_EXT.Length));

                using (XORParser parser = new XORParser(file, fileNoExt + Constants.IMG_EXT))
                {
                    parser.CryptFiles();
                }
            }

            return null;
        }

        public string Folder2Pak(string fileName)
        {
            if (!Directory.Exists(dir))
            {
                return "Specified directory doesn't exist!";
            }

            if (!File.Exists(zipPath))
            {
                return "Specified folder doesn't exist!";
            }

            string[] foils = Directory.GetFiles(dir, "*" + Constants.IMG_EXT, SearchOption.AllDirectories);
            foreach (string file in foils)
            {
                string fileNoExt = file.Substring(file.Length - (Constants.IMG_EXT.Length));

                using (XORParser parser = new XORParser(file, fileNoExt + Constants.DAT_EXT))
                {
                    parser.CryptFiles();
                }
            }

            ZipFile.CreateFromDirectory(zipPath, fileName);

            File.Move(zipPath, dir + fileName + Constants.PAK_EXT);

            return null;
        }
    }
}
