using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace AOS2Ripper.Parsers
{
    public class PakManager
    {
        private string zipPath;
        private string dir;

        public PakManager(string zipPath, string dir)
        {
            this.zipPath = zipPath;
            this.dir = dir;
        }

        public string Pak2Folder()
        {
            if (!File.Exists(zipPath))
            {
                return "Specified file doesn't exist!";
            }

            if (!Directory.Exists(dir))
            {
                return "Specified directory doesn't exist!";
            }

            string folderName = Path.GetFileNameWithoutExtension(zipPath);
            dir += "\\" + folderName;
            if (Directory.Exists(dir))
            {
                return "The folder you tried extracting the files to already contains a folder with the name \"" + folderName + ".\" Please rename that folder or choose another directory.";
            }

            Program.WriteDebugText("Extracting .pak file...");
            Directory.CreateDirectory(dir);
            ZipFile.ExtractToDirectory(zipPath, dir);

            string[] foils = Directory.GetFiles(dir, "*" + Constants.DAT_EXT, SearchOption.AllDirectories);
            Program.WriteDebugText("\nExtraction complete.");
            Program.WriteDebugText("Converting .dat files...");
            foreach (string file in foils)
            {
                string fileNoExt = file.Substring(0, file.Length - (Constants.DAT_EXT.Length));

                string inFilePath = file.Substring(dir.Length + 1);
                string outFilePath = "NaN";
                try
                {
                    using (XORParser parser = new XORParser(file, fileNoExt, false))
                    {
                        parser.CryptFiles();
                        outFilePath = parser.OutFileName.Substring(dir.Length + 1);
                    }

                    File.Delete(file);
                    Program.WriteDebugText("  Parsed file: " + inFilePath + " -> " + outFilePath, Color.DarkCyan);
                }
                catch (Exception e)
                {
                    Program.WriteDebugText("  Error occured with file " + Path.GetFileName(file) + "!", Color.Red);
                    Program.WriteDebugText("  " + e.Message + " -> " + e.StackTrace, Color.Red);
                }
            }

            Program.WriteDebugText("\n" + Path.GetFileName(zipPath) + " extracted succesfully!\n\n", Color.Green);
            return null;
        }

        public string Folder2Pak()
        {
            if (!Directory.Exists(dir))
            {
                return "Specified directory doesn't exist!";
            }

            string[] foils = Directory.GetFiles(dir, "*" + Constants.IMG_EXT, SearchOption.AllDirectories);
            foreach (string file in foils)
            {
                string fileNoExt = file.Substring(file.Length - (Constants.IMG_EXT.Length));

                string inFilePath = file.Substring(dir.Length + 1);
                string outFilePath = fileNoExt.Substring(dir.Length + 1) + Constants.DAT_EXT;
                try
                {
                    using (XORParser parser = new XORParser(file, fileNoExt + Constants.DAT_EXT, true))
                    {
                        parser.CryptFiles();
                    }

                    Program.WriteDebugText("Parsed file: " + inFilePath + " -> " + outFilePath, Color.AliceBlue);
                }
                catch (Exception e)
                {
                    Program.WriteDebugText("Error occured with file " + inFilePath + "!", Color.Red);
                    Program.WriteDebugText(e.Message + " -> " + e.StackTrace, Color.Red);
                }
            }

            Program.WriteDebugText("\n\nCreating .pak file...");
            ZipFile.CreateFromDirectory(dir, zipPath);

            //File.Move(zipPath, dir + fileName + Constants.PAK_EXT);
            Program.WriteDebugText("\n" + Path.GetFileName(zipPath) + " created succesfully!\n\n", Color.Green);

            return null;
        }
    }
}
