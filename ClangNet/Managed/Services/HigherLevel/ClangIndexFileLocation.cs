namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index File Location
    /// </summary>
    public class ClangIndexFileLocation : ClangPhysicalLocation
    {
        /// <summary>
        /// Clang Index Client File
        /// </summary>
        public ClangIndexClientFile IndexClientFile { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="index_client_file">Clang Index Client File</param>
        /// <param name="file">Clang File</param>
        /// <param name="line">Line</param>
        /// <param name="column">Column</param>
        /// <param name="offset">Offset</param>
        public ClangIndexFileLocation(ClangIndexClientFile index_client_file, ClangFile file, uint line, uint column, uint offset)
            : base(file, line, column, offset)
        {
            this.IndexClientFile = index_client_file;
        }
    }
}
