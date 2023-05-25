using Panosen.Toolkit;
using System.IO;
using System.Text;

namespace Panosen.Generation
{
    /// <summary>
    /// Package Extension
    /// </summary>
    public static class PackageExtension
    {

        /// <summary>
        /// 写入到文件夹
        /// </summary>
        public static void WriteTo(this Package package, string output)
        {
            WriteTo(package, output, Encoding.UTF8);
        }

        /// <summary>
        /// 写入到文件夹
        /// </summary>
        public static void WriteTo(this Package package, string output, Encoding defaultEncoding)
        {
            foreach (var item in package.Files)
            {
                var path = Path.Combine(output, item.FilePath);

                var fileDirectory = Path.GetDirectoryName(path);
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }

                if (item.SkipIfExists && File.Exists(path))
                {
                    continue;
                }

                if (item is PlainFile)
                {
                    var plainFile = item as PlainFile;
                    var finalEncodig = plainFile.Encoding ?? defaultEncoding ?? Encoding.UTF8;
                    if (File.Exists(path) && Hash.SHA256HEX(File.ReadAllBytes(path)) == Hash.SHA256HEX(finalEncodig.GetBytes(((PlainFile)item).Content)))
                    {
                        continue;
                    }
                    File.WriteAllText(path, ((PlainFile)item).Content, finalEncodig);
                }

                if (item is BytesFile)
                {
                    if (File.Exists(path) && Hash.SHA256HEX(File.ReadAllBytes(path)) == Hash.SHA256HEX(((BytesFile)item).Bytes))
                    {
                        continue;
                    }
                    File.WriteAllBytes(path, ((Panosen.Generation.BytesFile)item).Bytes);
                }
            }
        }
    }
}
