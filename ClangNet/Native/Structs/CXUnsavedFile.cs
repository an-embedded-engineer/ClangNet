using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ClangNet.Native
{
    /// <summary>
    /// Native Clang Unsaved File
    /// </summary>
    /// <remarks>
    /// Provides the contents of a file that has not yet been saved to disk.
    /// 
    /// Each <c>CXUnsavedFile</c> instance provides the name of a file on the
    /// system along with the current contents of that file that have not
    /// yet been saved to disk.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CXUnsavedFile
    {
        /// <summary>
        /// Filename
        /// </summary>
        /// <remarks>
        /// The file whose contents have not yet been saved.
        /// This file must already exist in the file system.
        /// </remarks>
        public readonly string FileName;

        /// <summary>
        /// Contents
        /// </summary>
        /// <remarks>
        /// A buffer containing the unsaved contents of this file.
        /// </remarks>
        public readonly string Contents;

        /// <summary>
        /// Contents Length
        /// </summary>
        /// <remarks>
        /// The length of the unsaved contents of this buffer.
        /// </remarks>
        public readonly uint Length;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filename">The file whose contents have not yet been saved.</param>
        /// <param name="contents">A buffer containing the unsaved contents of this file.</param>
        public CXUnsavedFile(string filename, string contents)
        {
            this.FileName = filename;
            this.Contents = contents;
            this.Length = (uint)contents.Length;
        }
    }
}
