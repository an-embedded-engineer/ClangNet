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
    /// Clang Object
    /// </summary>
    public class ClangObject
    {
        /// <summary>
        /// Native Clang Object Pointer
        /// </summary>
        internal IntPtr Handle { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Native Clang Object Pointer</param>
        internal ClangObject(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
            {
                throw new ArgumentNullException("Handle is null");
            }
            else
            {
                this.Handle = handle;
            }
        }
    }
}
