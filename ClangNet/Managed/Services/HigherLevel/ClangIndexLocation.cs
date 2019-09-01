using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Location
    /// </summary>
    public class ClangIndexLocation
    {
        /// <summary>
        /// Native Clang Index Location
        /// </summary>
        internal CXIdxLoc Source { get; }

        /// <summary>
        /// Clang Source Location
        /// </summary>
        public ClangSourceLocation SourceLocation
        {
            get { return LibClang.clang_indexLoc_getCXSourceLocation(this.Source).ToManaged(); }
        }

        /// <summary>
        /// Clang Index File Location
        /// </summary>
        public ClangIndexFileLocation FileLocation
        {
            get
            {
                LibClang.clang_indexLoc_getFileLocation(this.Source, out var native_index_file, out var native_file, out var line, out var column, out var offset);

                var index_file = native_index_file.ToManaged<ClangIndexClientFile>();

                var file = native_file.ToManaged<ClangFile>();

                return new ClangIndexFileLocation(index_file, file, line, column, offset);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">Native Clang Index Location</param>
        internal ClangIndexLocation(CXIdxLoc source)
        {
            this.Source = source;
        }
    }
}
