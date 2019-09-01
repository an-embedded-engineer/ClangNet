using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClangNet
{
    /// <summary>
    /// File Manager
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Analyse File Encoding
        /// </summary>
        /// <param name="path">File Path</param>
        /// <returns>File Encoding</returns>
        public static Encoding AnalyseEncoding(string path)
        {
            if (File.Exists(path))
            {
                var bytes = File.ReadAllBytes(path);

                var enc = EncodingAnalyser.Analyse(bytes);

                return enc;
            }
            else
            {
                throw new ArgumentException($"File Not Found : {path}");
            }
        }
    }
}