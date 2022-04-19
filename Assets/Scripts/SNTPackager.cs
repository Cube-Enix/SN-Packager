using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

public class SNTPackager : MonoBehaviour
{
    public static SNTPackager instance;

    private void Start()
    {
        instance = this;
    }

    public void compressDirectory(string DirectoryPath, string OutputFilePath, int CompressionLevel = 9)
    {
        // Depending on the directory this could be very large and would require more attention
        // in a commercial package.
        string[] filenames = Directory.GetFiles(DirectoryPath);

        // 'using' statements guarantee the stream is closed properly which is a big source
        // of problems otherwise.  Its exception safe as well which is great.
        using (ZipOutputStream OutputStream = new ZipOutputStream(File.Create(OutputFilePath)))
        {

            // Define the compression level
            // 0 - store only to 9 - means best compression
            OutputStream.SetLevel(CompressionLevel);

            byte[] buffer = new byte[4096];

            foreach (string file in filenames)
            {
                if (!file.Contains(".meta"))
                {

                    // Using GetFileName makes the result compatible with XP
                    // as the resulting path is not absolute.
                    ZipEntry entry = new ZipEntry(Path.GetFileName(file));

                    // Setup the entry data as required.

                    // Crc and size are handled by the library for seakable streams
                    // so no need to do them here.

                    // Could also use the last write time or similar for the file.
                    entry.DateTime = System.DateTime.Now;
                    OutputStream.PutNextEntry(entry);

                    using (FileStream fs = File.OpenRead(file))
                    {

                        // Using a fixed size buffer here makes no noticeable difference for output
                        // but keeps a lid on memory usage.
                        int sourceBytes;

                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            OutputStream.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                }
            }

            // Finish/Close arent needed strictly as the using statement does this automatically

            // Finish is important to ensure trailing information for a Zip file is appended.  Without this
            // the created file would be invalid.
            OutputStream.Finish();

            // Close is important to wrap things up and unlock the file.
            OutputStream.Close();

            Debug.Log("Files successfully compressed");
        }
    }
}
