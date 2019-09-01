using System;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Index Client AST File
    /// </summary>
    public class ClangIndexClientASTFile : ClangIndexInfo
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">Native Clang Index Client AST File Address</param>
        internal ClangIndexClientASTFile(IntPtr address) : base(address)
        {
        }
    }
}
