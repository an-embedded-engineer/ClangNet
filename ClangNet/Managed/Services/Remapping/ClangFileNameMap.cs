namespace ClangNet
{
    /// <summary>
    /// Managed Clang File Map
    /// </summary>
    public struct ClangFileNameMap
    {
        /// <summary>
        /// Original File Name
        /// </summary>
        public string Original { get; }

        /// <summary>
        /// Transformed File Name
        /// </summary>
        public string Transformed { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original File Name</param>
        /// <param name="transformed">Transformed File Name</param>
        internal ClangFileNameMap(string original, string transformed)
        {
            this.Original = original;

            this.Transformed = transformed;
        }
    }
}
