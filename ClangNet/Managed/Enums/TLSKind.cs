using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClangNet
{
    /// <summary>
    /// TLS(Thread Local Storage) Kind
    /// </summary>
    /// <remarks>
    /// Describe the "thread-local storage (TLS) kind" of the declaration
    /// referred to by a cursor.
    /// </remarks>
    public enum TLSKind
    {
        /// <summary>
        /// None
        /// </summary>
        None,

        /// <summary>
        /// Dynamic
        /// </summary>
        Dynamic,

        /// <summary>
        /// Static
        /// </summary>
        Static,
    }
}
