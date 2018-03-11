using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;

namespace AOS2Ripper.Parsers
{
    public class PakManager
    {
        private string zipPath;
        private string dir;

        private readonly Color parsedFileColor = Color.Blue;

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

            for (int i = 0; i < foils.Length; i++)
            {
                string fileNoExt = Path.ChangeExtension(foils[i], null);

                string inFilePath = foils[i].Substring(dir.Length + 1);
                string outFilePath = "NaN";
                try
                {
                    using (XORParser parser = new XORParser(foils[i], fileNoExt, false))
                    {
                        parser.CryptFiles();
                        outFilePath = parser.OutFileName.Substring(dir.Length + 1);
                    }

                    File.Delete(foils[i]);
                    Program.WriteDebugText("  Parsed file: " + inFilePath + " -> " + outFilePath, parsedFileColor);
                }
                catch (Exception e)
                {
                    Program.WriteDebugText("  Error occured with file " + Path.GetFileName(foils[i]) + "!", Color.Red);
                    Program.WriteDebugText("  " + e.Message + " -> " + e.StackTrace, Color.Red);
                }

                Program.MainForm.StepProgress((i + 1) * 100 / foils.Length);
            }

            Program.WriteDebugText("\n" + Path.GetFileName(zipPath) + " extracted successfully!", Color.Green);
            return null;
        }

        public string Folder2Pak()
        {
            if (!Directory.Exists(dir))
            {
                return "Specified directory doesn't exist!";
            }

            Program.WriteDebugText("Encrypting files...");
            string[] foils = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(Constants.IMG_EXT) || s.EndsWith(Constants.GENERIC_EXT)).ToArray();
            string tempDir = GetTemporaryDirectory();

            for (int i = 0; i < foils.Length; i++)
            {
                string fileNoExt = Path.ChangeExtension(foils[i], null);

                string inFilePath = foils[i].Substring(dir.Length + 1);
                string outFilePath = fileNoExt.Substring(dir.Length + 1) + Constants.DAT_EXT;
                try
                {
                    if (!Directory.Exists(tempDir + outFilePath))
                    {
                        Directory.CreateDirectory(tempDir + Path.GetDirectoryName(outFilePath));
                    }

                    using (XORParser parser = new XORParser(foils[i], tempDir + outFilePath, true))
                    {
                        parser.CryptFiles();
                    }
                    
                    Program.WriteDebugText("  Parsed file: " + inFilePath + " -> " + outFilePath, parsedFileColor);
                }
                catch (Exception e)
                {
                    Program.WriteDebugText("  Error occured with file " + inFilePath + "!", Color.Red);
                    Program.WriteDebugText(e.Message + " -> " + e.StackTrace, Color.Red);
                }

                Program.MainForm.StepProgress((i + 1) * 100 / foils.Length);
            }

            Program.WriteDebugText("\nEncryption complete.");
            Program.WriteDebugText("Creating .pak file...");

            // User is prompted about overwriting prior to reaching this point.
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }
            ZipFile.CreateFromDirectory(tempDir, zipPath);

            Program.WriteDebugText("Cleaning up...");
            Directory.Delete(tempDir, true);

            Program.WriteDebugText("\n" + Path.GetFileName(zipPath) + " created successfully!", Color.Green);

            return null;
        }

        private string GetTemporaryDirectory()
        {
            string tempDirectory = null;
            do
            {
                tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            }
            while (Directory.Exists(tempDirectory));

            Directory.CreateDirectory(tempDirectory);
            return tempDirectory + "\\";
        }
    }
}
