using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ClangNet.Native;

namespace ClangNet
{
    /// <summary>
    /// Managed Clang File
    /// </summary>
    public class ClangFile : ClangObject
    {
        /// <summary>
        /// File Name
        /// </summary>
        public string FileName
        {
            get { return LibClang.clang_getFileName(this.Handle).ToManaged(); }
        }

        /// <summary>
        /// File Last Modification Time
        /// </summary>
        public long FileTime
        {
            get { return LibClang.clang_getFileTime(this.Handle); }
        }

        /// <summary>
        /// Clang File Unique ID
        /// </summary>
        public ClangFileUniqueId FileUniqueId
        {
            get
            {
                var ret = LibClang.clang_getFileUniqueID(this.Handle, out var out_id);

                if (ret != 0)
                {
                    throw new ClangServiceException($"Get File Unique ID Failed : {this.FileName} - Error Code : {ret}");
                }

                return out_id.ToManaged();
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang File Pointer</param>
        internal ClangFile(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Try Get Real Path Name
        /// </summary>
        /// <returns>Real Path Name</returns>
        public string TryGetRealPathName()
        {
            return LibClang.clang_File_tryGetRealPathName(this.Handle).ToManaged();
        }

        /// <summary>
        /// Convert to String
        /// </summary>
        /// <returns>File Name</returns>
        public override string ToString()
        {
            return this.FileName;
        }
    }
}
