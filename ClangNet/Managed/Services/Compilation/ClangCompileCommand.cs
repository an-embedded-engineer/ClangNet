using System;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Compile Command
    /// </summary>
    public class ClangCompileCommand : ClangObject
    {
        /// <summary>
        /// Directory
        /// </summary>
        public string Directory
        {
            get { return LibClang.clang_CompileCommand_getDirectory(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// Filename
        /// </summary>
        public string Filename
        {
            get { return LibClang.clang_CompileCommand_getFilename(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// Argument Count
        /// </summary>
        public int ArgumentCount
        {
            get { return (int)LibClang.clang_CompileCommand_getNumArgs(this.Handle); }
        }

        /// <summary>
        /// Mapped Source Count
        /// </summary>
        public int MappedSourceCount
        {
            get { return (int)LibClang.clang_CompileCommand_getNumMappedSources(this.Handle); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Compile Command Pointer</param>
        internal ClangCompileCommand(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Get Argument
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Argument</returns>
        public string GetArgument(int i)
        {
            return LibClang.clang_CompileCommand_getArg(this.Handle, (uint)i).ToManaged();
        }

        /// <summary>
        /// Get Mapped Source Path
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Mapped Source Path</returns>
        public string GetMappedSourcePath(int i)
        {
            return LibClang.clang_CompileCommand_getMappedSourcePath(this.Handle, (uint)i).ToManaged();
        }

        /// <summary>
        /// Get Mapped Source Content
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Mapped Source Content</returns>
        public string GetMappedSourceContent(int i)
        {
            return LibClang.clang_CompileCommand_getMappedSourceContent(this.Handle, (uint)i).ToManaged();
        }
    }
}
