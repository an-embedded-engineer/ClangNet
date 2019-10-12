namespace ClangNet.Samples
{
    /// <summary>
    /// Managed Clang Source Location Extensions
    /// </summary>
    public static class ClangSourceLocationEx
    {
        /// <summary>
        /// Get File Path
        /// </summary>
        /// <param name="loc">Clang Source Location</param>
        /// <param name="absolute">Absolute Path Flag</param>
        /// <returns>File Path</returns>
        public static string GetFilePath(this ClangSourceLocation loc, bool absolute = false)
        {
            var floc = loc.FileLocation;

            var file = absolute ? floc.File.ToFullPath() : floc.File.FileName.Replace(@"\", "/");

            return file;
        }

        /// <summary>
        /// Convert to String Extended
        /// </summary>
        /// <param name="loc">Clang Source Location</param>
        /// <param name="absolute">Absolute Path Flag</param>
        /// <returns>Source Location</returns>
        public static string ToStringEx(this ClangSourceLocation loc, bool absolute = false)
        {
            var floc = loc.FileLocation;

            if(floc.File != null)
            {
                var file = absolute ? floc.File.ToFullPath() : floc.File.FileName.Replace(@"\", "/");

                var line = floc.Line;

                var col = floc.Column;

                return $"{file}[L.{line},C.{col}]";
            }
            else
            {
                return "";
            }
        }
    }

}
