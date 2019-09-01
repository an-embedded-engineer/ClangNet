using System.IO;

namespace ClangNet.Samples
{
    /// <summary>
    /// Managed Clang File Extensions
    /// </summary>
    public static class ClangFileEx
    {
        /// <summary>
        /// Convert to Full Path
        /// </summary>
        /// <param name="file">Clang File</param>
        /// <returns>Full Path</returns>
        public static string ToFullPath(this ClangFile file)
        {
            var file_name = Path.GetFullPath(file.FileName);

            return file_name.Replace(@"\", @"/");
        }
    }

}
