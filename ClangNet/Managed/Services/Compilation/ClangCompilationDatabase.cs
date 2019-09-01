using System;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Compilation Database
    /// </summary>
    public class ClangCompilationDatabase : ClangObject, IDisposable
    {
        /// <summary>
        /// All Clang Compile Commands
        /// </summary>
        public ClangCompileCommands AllCompileCommands
        {
            get { return LibClang.clang_CompilationDatabase_getAllCompileCommands(this.Handle).ToManaged<ClangCompileCommands>(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Compilation Database Pointer</param>
        internal ClangCompilationDatabase(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Get Clang Compile Command
        /// </summary>
        /// <param name="complete_filename">Complete Filename</param>
        /// <returns>Clang Compile Command</returns>
        public ClangCompileCommands GetCompileCommands(string complete_filename)
        {
            return LibClang.clang_CompilationDatabase_getCompileCommands(this.Handle, complete_filename).ToManaged<ClangCompileCommands>();
        }

        /// <summary>
        /// Dispose Clang Compilation Database
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_CompilationDatabase_dispose(this.Handle);
        }
    }
}
