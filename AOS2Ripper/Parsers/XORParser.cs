using System;
using System.IO;
using System.Text;

namespace AOS2Ripper.Parsers
{
    public class XORParser : IDisposable
    {
        private readonly byte[] PNG_HEADER = { 0x89, 0x50, 0x4E, 0x47 };
        private const int CHUNK_SIZE = 1024 * 4;
        private string key;

        private BinaryReader inputFile;
        private BinaryWriter outputFile;
        public string OutFileName { private set; get; }

        public XORParser(string inputFile, string outputFile, bool hasExt)
        {
            key = "u73$@STKY%&F#K;;zZTY%JM2@{}}1HsdbtyJU+g2j9ZXSc;32<%&v#&>_vDHYwQWJKIJs67?*e'-wBJ3#!)FVh!)O";
            this.inputFile = new BinaryReader(new FileStream(inputFile, FileMode.Open));

            // If the file's a PNG make the output a .png, otherwise use .dump.
            string outer = outputFile;
            if (!hasExt)
            {
                if (isPNG())
                {
                    outer += Constants.IMG_EXT;
                }
                else
                {
                    outer += Constants.GENERIC_EXT;
                }
            }

            this.outputFile = new BinaryWriter(File.Create(outer));
            this.OutFileName = outer;
        }
        
        public void Dispose()
        {
            inputFile.Dispose();
            outputFile.Dispose();

            key = null;
        }

        /// <summary>
        /// Check that the header of the file is that of a PNG.
        /// </summary>
        public bool isPNG()
        {
            byte[] header = inputFile.ReadBytes(4);
            byte[] bytKey = Encoding.ASCII.GetBytes(key.ToCharArray(), 0, 4);
            for (int  i = 0; i < header.Length; i++)
            {
                if (EncryptDecrypt(bytKey[i % bytKey.Length], header[i]) != PNG_HEADER[i])
                {
                    // Set the stream position to the beginning of the file.
                    inputFile.BaseStream.Seek(0, SeekOrigin.Begin);

                    return false;
                }
            }

            // Set the stream position to the beginning of the file.
            inputFile.BaseStream.Seek(0, SeekOrigin.Begin);

            return true;
        }

        public void CryptFiles()
        {
            byte[] bytKey = Encoding.ASCII.GetBytes(key);

            long chunkCount = inputFile.BaseStream.Length / CHUNK_SIZE;
            // Assuming the file's byte size is not a multiple of the chunk size, add an actually iteration
            // for any remaining bytes.
            if (inputFile.BaseStream.Length % CHUNK_SIZE != 0)
            {
                chunkCount++;
            }

            int currentByte = 0;
            for (int i = 0; i < chunkCount; i++)
            {
                byte[] bytes = inputFile.ReadBytes((int) Math.Min(inputFile.BaseStream.Length - i, CHUNK_SIZE));
                for (int j = 0; j < bytes.Length; j++)
                {
                    byte encryptKey = bytKey[currentByte % bytKey.Length];
                    byte toEncrypt = bytes[j];

                    byte encrypted = EncryptDecrypt(encryptKey, toEncrypt);
                    outputFile.Write(encrypted);

                    currentByte++;
                }
            }
        }

        private byte EncryptDecrypt(byte key, byte code)
        {
            return (byte) (key ^ code);
        }
    }
}
