using System;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Compile Commands
    /// </summary>
    public class ClangCompileCommands : ClangObject, IDisposable
    {
        /// <summary>
        /// Count of Clang Compile Command
        /// </summary>
        public int Count
        {
            get { return (int)LibClang.clang_CompileCommands_getSize(this.Handle); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Compile Commands Pointer</param>
        internal ClangCompileCommands(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Get Clang Compile Command
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Clang Compile Command</returns>
        public ClangCompileCommand GetCommand(int i)
        {
            return LibClang.clang_CompileCommands_getCommand(this.Handle, (uint)i).ToManaged<ClangCompileCommand>();
        }

        /// <summary>
        /// Dispose Clang Compile Commands
        /// </summary>
        public void Dispose()
        {
            LibClang.clang_CompileCommands_dispose(this.Handle);
        }
    }
}
