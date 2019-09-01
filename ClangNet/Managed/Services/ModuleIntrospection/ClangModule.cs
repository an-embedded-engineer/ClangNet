using System;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang Module
    /// </summary>
    public class ClangModule : ClangObject
    {
        /// <summary>
        /// AST Clang File
        /// </summary>
        public ClangFile ASTFile
        {
            get { return LibClang.clang_Module_getASTFile(this.Handle).ToManaged<ClangFile>(); }
        }

        /// <summary>
        /// Parent Clang Module
        /// </summary>
        public ClangModule Parent
        {
            get { return LibClang.clang_Module_getParent(this.Handle).ToManaged<ClangModule>(); }
        }

        /// <summary>
        /// Module Name
        /// </summary>
        public string Name
        {
            get { return LibClang.clang_Module_getName(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// Module Full Name
        /// </summary>
        public string FullName
        {
            get { return LibClang.clang_Module_getFullName(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// System Module Flag
        /// </summary>
        public bool IsSystem
        {
            get { return LibClang.clang_Module_isSystem(this.Handle).ToBool(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Module Pointer</param>
        internal ClangModule(IntPtr handle) : base(handle)
        {
        }
    }
}
