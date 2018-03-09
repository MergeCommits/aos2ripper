using System;
using System.IO;

namespace AOS2Ripper.Parsers
{
    public class XORParser : IDisposable
    {
        private string key;

        private BinaryReader inputFile;
        private BinaryWriter outputFile;

        public XORParser(string inputFile, string outputFile)
        {
            key = "u73$@STKY%&F#K;;zZTY%JM2@{}}1HsdbtyJU+g2j9ZXSc;32<%&v#&>_vDHYwQWJKIJs67?*e'-wBJ3#!)FVh!)O";
            this.inputFile = new BinaryReader(new FileStream(inputFile, FileMode.Open));
            this.outputFile = new BinaryWriter(File.Create(outputFile));
        }
        
        public void Dispose()
        {
            inputFile.Dispose();
            outputFile.Dispose();

            key = null;
        }

        public void CryptFiles()
        {
            for (int i = 0; i < inputFile.BaseStream.Length; i++)
            {
                char toEncrypt = inputFile.ReadChar();
                char encrypted = (char) (toEncrypt ^ key[i % key.Length]);

                outputFile.Write(encrypted);
            }
        }
    }
}
